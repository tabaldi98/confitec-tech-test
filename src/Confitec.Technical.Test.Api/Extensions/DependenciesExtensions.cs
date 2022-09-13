using Confitec.Technical.Test.BackGround.Mail.MailRecoveryPassword;
using Confitec.Technical.Test.BackGround.Mail.MailSystemUserCreated;
using Confitec.Technical.Test.Domain.ParametersModule;
using Confitec.Technical.Test.Domain.RecoveryPasswordModule;
using Confitec.Technical.Test.Domain.SystemUserModule;
using Confitec.Technical.Test.Domain.UserModule;
using Confitec.Technical.Test.Infra.Crosscutting.Mail;
using Confitec.Technical.Test.Infra.Crosscutting.RabbitMq;
using Confitec.Technical.Test.Infra.Data;
using Confitec.Technical.Test.Infra.Data.ParametersModule;
using Confitec.Technical.Test.Infra.Data.RecoveryPasswordModule;
using Confitec.Technical.Test.Infra.Data.UserModule;

namespace Confitec.Technical.Test.Api.Extensions
{
    public static class DependenciesExtensions
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddDbContext<TechnicalTestContext>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ISystemUserRepository, SystemUserRepository>();
            services.AddScoped<IParameterRepository, ParameterRepository>();
            services.AddScoped<IRecoveryPasswordRepository, RecoveryPasswordRepository>();

            services.AddSingleton<IRabbitMqConnector, RabbitMqConnector>();
            services.AddSingleton<IMailSender, MailSender>();

            services.AddHostedService<MailRecoveryPasswordBackgroundService>();
            services.AddHostedService<MailSystemUserCreatedBackgroundService>();
        }
    }
}
