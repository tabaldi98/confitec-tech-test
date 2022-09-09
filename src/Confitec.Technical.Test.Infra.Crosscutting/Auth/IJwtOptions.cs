using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Confitec.Technical.Test.Infra.Crosscutting.Auth
{
    public interface IJwtOptions
    {
        string Issuer { get; }
        string Audience { get; }
        int ExpirationMinutes { get; }
        bool RequireHttpsMetadata { get; }
        SymmetricSecurityKey SymmetricSecurityKey { get; }
        SigningCredentials SigningCredentials { get; }
        DateTime IssuedAt { get; }
        DateTime NotBefore { get; }
        DateTime AccessTokenExpiration { get; }

        void SetExpiration(int expirationMinutes);
    }

    public class JwtOptions : IJwtOptions
    {
        public string Issuer { get; }
        public string Audience { get; }
        public int ExpirationMinutes { get; private set; }
        public bool RequireHttpsMetadata { get; }
        public SymmetricSecurityKey SymmetricSecurityKey { get; }
        public SigningCredentials SigningCredentials { get; }

        public DateTime IssuedAt => DateTime.UtcNow;
        public DateTime NotBefore => IssuedAt;
        public DateTime AccessTokenExpiration => IssuedAt.AddMinutes(ExpirationMinutes);

        public JwtOptions(IConfiguration configuration)
        {
            Issuer = configuration.GetSection("AuthOptions").GetValue<string>("Issuer");
            Audience = configuration.GetSection("AuthOptions").GetValue<string>("Audience");
            ExpirationMinutes = 120;
            RequireHttpsMetadata = false;

            var signingKey = configuration.GetSection("AuthOptions").GetValue<string>("Secret");
            SymmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey));
            SigningCredentials = new SigningCredentials(SymmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);
        }

        public void SetExpiration(int expirationMinutes)
        {
            ExpirationMinutes = expirationMinutes;
        }
    }
}
