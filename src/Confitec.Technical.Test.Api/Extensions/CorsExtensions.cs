namespace Confitec.Technical.Test.Api.Extensions
{
    public static class CorsExtensions
    {
        private static string CorsName = "ApiCorsPolicy";

        public static void AddCors(this WebApplicationBuilder builder)
        {
            builder.Services.AddCors(p => p.AddPolicy(CorsName, p =>
            {
                p.WithOrigins()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true)
                .AllowCredentials()
                .Build();
            }));
        }

        public static void UseCustomCors(this IApplicationBuilder app)
        {
            app.UseCors(CorsName);
        }
    }
}
