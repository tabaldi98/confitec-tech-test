using Confitec.Technical.Test.Infra.Crosscutting.RabbitMq;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client.Events;
using System.Text;
using RabbitMQ.Client;
using Confitec.Technical.Test.Infra.Crosscutting.Mail;

namespace Confitec.Technical.Test.BackGround.Mail.MailSystemUserCreated
{
    public class MailSystemUserCreatedBackgroundService : BackgroundService
    {
        private readonly IRabbitMqConnector _rabbitMqConnector;
        private readonly IMailSender _mailSender;

        public MailSystemUserCreatedBackgroundService(
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

                var isSucess = await _mailSender.SendAsync(message.AdminMail, message.AdminFullName, "Aviso de usuário criado", TextTemplate(message), HtmlTemplate(message));

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
                queue: RabbitMqConstants.QUEUE_SYSTEM_USER_CREATED,
                consumer: consumer,
                consumerTag: "mail-user-consumer-" + Environment.MachineName);

            return Task.CompletedTask;
        }

        private string HtmlTemplate(MailModel mailModel)
        {
            return @$"
                    <p>Olá <strong>{mailModel.AdminFullName}.</strong></p>
                    <p>Foi criado o usuário <strong>{mailModel.UserNameCreated}</strong> com os seguintes dados:</p>
                    <p>Nome completo <strong>{mailModel.UserFullNameCreated}</strong></p>
                    <p>E-mail <strong>{mailModel.UserMailCreated}</strong></p>";
        }

        private string TextTemplate(MailModel mailModel)
        {
            return @$"
                    Olá {mailModel.AdminFullName}.
                    Foi criado o usuário <strong>{mailModel.UserNameCreated} com os seguintes dados:
                    Nome completo {mailModel.UserFullNameCreated}
                    E-mail {mailModel.UserMailCreated}";
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