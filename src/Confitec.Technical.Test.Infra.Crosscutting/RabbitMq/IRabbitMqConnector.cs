using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace Confitec.Technical.Test.Infra.Crosscutting.RabbitMq
{
    public interface IRabbitMqConnector : IDisposable
    {
        IModel Channel { get; }
        void PublishMessage(object message, string exchange, string routingKey);
    }

    public class RabbitMqConnector : IRabbitMqConnector
    {
        public IModel Channel { get; private set; }

        private readonly IConfiguration _configuration;

        public RabbitMqConnector(IConfiguration configuration)
        {
            _configuration = configuration;
            var factory = new ConnectionFactory()
            {
                HostName = _configuration.GetSection("RabbitMq").GetValue<string>("HostName"),
                Port = _configuration.GetSection("RabbitMq").GetValue<int>("Port"),
                UserName = _configuration.GetSection("RabbitMq").GetValue<string>("UserName"),
                Password = _configuration.GetSection("RabbitMq").GetValue<string>("Password"),
            };
            Channel = factory.CreateConnection().CreateModel();

            // Recovery password
            Channel.ExchangeDeclare(RabbitMqConstants.EXCHANGE_MAIL_RECOVERY, ExchangeType.Topic);
            Channel.QueueDeclare(RabbitMqConstants.QUEUE_MAIL_RECOVERY, false, false, false, null);
            Channel.QueueBind(RabbitMqConstants.QUEUE_MAIL_RECOVERY, RabbitMqConstants.EXCHANGE_MAIL_RECOVERY, RabbitMqConstants.ROUTING_KEY_MAIL_RECOVERY, null);

            // System user created
            Channel.ExchangeDeclare(RabbitMqConstants.EXCHANGE_SYSTEM_USER_CREATED, ExchangeType.Topic);
            Channel.QueueDeclare(RabbitMqConstants.QUEUE_SYSTEM_USER_CREATED, false, false, false, null);
            Channel.QueueBind(RabbitMqConstants.QUEUE_SYSTEM_USER_CREATED, RabbitMqConstants.EXCHANGE_SYSTEM_USER_CREATED, RabbitMqConstants.ROUTING_KEY_SYSTEM_USER_CREATE, null);
        }

        public void PublishMessage(object message, string exchange, string routingKey)
        {
            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);

            Channel.BasicPublish(exchange, routingKey, body: body);
        }

        public void Dispose()
        {
            Channel.Close();
            Channel.Dispose();
        }
    }
}
