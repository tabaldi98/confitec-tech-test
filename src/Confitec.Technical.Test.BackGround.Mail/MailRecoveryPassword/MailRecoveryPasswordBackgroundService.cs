using Confitec.Technical.Test.Infra.Crosscutting.RabbitMq;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client.Events;
using System.Text;
using RabbitMQ.Client;
using Confitec.Technical.Test.Infra.Crosscutting.Mail;

namespace Confitec.Technical.Test.BackGround.Mail.MailRecoveryPassword
{
    public class MailRecoveryPasswordBackgroundService : BackgroundService
    {
        private readonly IRabbitMqConnector _rabbitMqConnector;
        private readonly IMailSender _mailSender;

        public MailRecoveryPasswordBackgroundService(
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

                var isSucess = await _mailSender.SendAsync(message.Mail, message.FullName, "Recuperação de senha", TextTemplate(message.FullName, message.Code), HtmlTemplate(message.FullName, message.Code));

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
                queue: RabbitMqConstants.QUEUE_MAIL_RECOVERY,
                consumer: consumer,
                consumerTag: "mail-consumer-" + Environment.MachineName);

            return Task.CompletedTask;
        }

        private string HtmlTemplate(string fullName, string code)
        {
            return @$"
                    <p>Olá <strong>{fullName}.</strong></p>
                    <p>Informe o código <strong>{code}</strong> para recuperar sua senha.</p>";
        }

        private string TextTemplate(string fullName, string code)
        {
            return @$"
                    Olá {fullName}.
                    Informe o código {code} para recuperar sua senha.";
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