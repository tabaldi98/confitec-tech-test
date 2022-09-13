using RabbitMQ.Client;
using Serilog;

namespace Confitec.Technical.Test.Api.Extensions
{
    public static class HealthCheckExtension
    {
        public static void AddHealthCheck(this WebApplicationBuilder builder)
        {
            builder.Services.AddHealthChecks()
                .AddSqlServer(builder.Configuration.GetConnectionString("TechnicalTest"))
                .AddRabbitMQ(a =>
                {
                    return new ConnectionFactory()
                    {
                        HostName = builder.Configuration.GetSection("RabbitMq").GetValue<string>("HostName"),
                        Port = builder.Configuration.GetSection("RabbitMq").GetValue<int>("Port"),
                        UserName = builder.Configuration.GetSection("RabbitMq").GetValue<string>("UserName"),
                        Password = builder.Configuration.GetSection("RabbitMq").GetValue<string>("Password"),
                    };
                });
        }
    }
}
