using Confitec.Technical.Test.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Confitec.Technical.Test.Api.Extensions
{
    public static class MigrationExtensions
    {
        public static void MigrationInitialisation(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                serviceScope.ServiceProvider.GetRequiredService<TechnicalTestContext>().Database.Migrate();
            }
        }
    }
}
