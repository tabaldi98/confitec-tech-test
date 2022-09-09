using Confitec.Technical.Test.Infra.Crosscutting.RabbitMq;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client.Events;
using System.Text;
using RabbitMQ.Client;
using Confitec.Technical.Test.Infra.Crosscutting.Mail;

namespace Confitec.Technical.Test.BackGround.Mail
{
    public class MailSenderBackgroundService : BackgroundService
    {
        private readonly IRabbitMqConnector _rabbitMqConnector;
        private readonly IMailSender _mailSender;

        public MailSenderBackgroundService(
            IRabbitMqConnector rabbitMqConnector,
            IMailSender mailSender)
        {
            _rabbitMqConnector = rabbitMqConnector;
            _mailSender = mailSender;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            var consumer = new EventingBasicConsumer(_rabbitMqConnector.Channel);

            consumer.Received += async (ch, eventArgs) =>
            {
                var message = JsonConvert.DeserializeObject<MailModel>(Encoding.Default.GetString(eventArgs.Body.ToArray()));

                var isSucess = await _mailSender.SendRecoveryPasswordAsync(message.Mail, message.FullName, message.Code);

                if (isSucess)
                {
                    _rabbitMqConnector.Channel.BasicAck(eventArgs.DeliveryTag, false);
                }
                else
                {
                    _rabbitMqConnector.Channel.BasicNack(eventArgs.DeliveryTag, false, true);
                }
            };

            _rabbitMqConnector.Channel.BasicConsume(
                queue: "mail.send",
                consumer: consumer,
                consumerTag: "mail-consumer-" + Environment.MachineName);

            return Task.CompletedTask;
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _rabbitMqConnector.Dispose();
            return base.StopAsync(cancellationToken);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Task.CompletedTask;
        }
    }
}