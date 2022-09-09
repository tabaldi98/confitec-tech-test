using Microsoft.AspNetCore.Mvc;

namespace Confitec.Technical.Test.Api.Extensions
{
    public static class VersioningExtension
    {
        public static void AddVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(p =>
            {
                p.UseApiBehavior = false;
                p.AssumeDefaultVersionWhenUnspecified = true;
                p.DefaultApiVersion = ApiVersion.Parse("1");
                p.ReportApiVersions = true;

                // V1
                p.Conventions.Controller(typeof(Controllers.V1.UserController)).HasApiVersion(ApiVersion.Parse("1"));
                p.Conventions.Controller(typeof(Controllers.V1.LoginController)).HasApiVersion(ApiVersion.Parse("1"));
                p.Conventions.Controller(typeof(Controllers.V1.SystemUserController)).HasApiVersion(ApiVersion.Parse("1"));
                p.Conventions.Controller(typeof(Controllers.V1.ParameterController)).HasApiVersion(ApiVersion.Parse("1"));
            });
        }
    }
}
