using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace Confitec.Technical.Test.Infra.Crosscutting.RabbitMq
{
    public interface IRabbitMqConnector : IDisposable
    {
        IModel Channel { get; }
        void SendMessage(object message);
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
                Uri = new Uri(_configuration.GetConnectionString("RabbitMq")),
            };
            Channel = factory.CreateConnection().CreateModel();
            Channel.ExchangeDeclare("mail", ExchangeType.Topic);
            Channel.QueueDeclare("mail.send", false, false, false, null);
            Channel.QueueBind("mail.send", "mail", "mail", null);
        }

        public void SendMessage(object message)
        {
            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);

            Channel.BasicPublish(exchange: "mail", routingKey: "mail", body: body);
        }

        public void Dispose()
        {
            Channel.Close();
            Channel.Dispose();
        }

    }
}
