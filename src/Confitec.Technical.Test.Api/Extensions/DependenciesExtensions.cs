using Confitec.Technical.Test.Domain.SystemUserModule;
using Confitec.Technical.Test.Domain.UserModule;
using Confitec.Technical.Test.Infra.Data;
using Confitec.Technical.Test.Infra.Data.UserModule;

namespace Confitec.Technical.Test.Api.Extensions
{
    public static class DependenciesExtensions
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ISystemUserRepository, SystemUserRepository>();

            services.AddDbContext<TechnicalTestContext>();
        }
    }
}
