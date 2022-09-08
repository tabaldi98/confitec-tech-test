using Confitec.Technical.Test.Infra.Crosscutting.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;

namespace Confitec.Technical.Test.Api.Extensions
{
    public static class AuthenticationExtensions
    {
        public static void AddJwtBearerAuthentication(this WebApplicationBuilder builder)
        {
            var jwtOptions = new JwtOptions(builder.Configuration);
            builder.Services.AddSingleton<IJwtOptions>(jwtOptions);

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.RequireHttpsMetadata = jwtOptions.RequireHttpsMetadata;
                        options.SaveToken = true;
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = jwtOptions.SymmetricSecurityKey,
                            ValidateIssuer = true,
                            ValidIssuer = jwtOptions.Issuer,
                            ValidateAudience = true,
                            ValidAudience = jwtOptions.Audience,
                            ValidateLifetime = true,
                            ClockSkew = TimeSpan.Zero
                        };
                    });

            builder.Services.AddAuthorization(p =>
            {
                p.DefaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme).RequireAuthenticatedUser().Build();
            });
        }
    }
}
