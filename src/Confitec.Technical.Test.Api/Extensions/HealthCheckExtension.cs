using RabbitMQ.Client;
using Serilog;

namespace Confitec.Technical.Test.Api.Extensions
{
    public static class HealthCheckExtension
    {
        public static void AddHealthCheck(this WebApplicationBuilder builder)
        {
            Console.WriteLine(builder.Configuration.GetConnectionString("RabbitMq"));
            builder.Services.AddHealthChecks()
                .AddSqlServer(builder.Configuration.GetConnectionString("TechnicalTest"))
                .AddRabbitMQ(builder.Configuration.GetConnectionString("RabbitMq"), name: "RabbitMq");
        }
    }
}
