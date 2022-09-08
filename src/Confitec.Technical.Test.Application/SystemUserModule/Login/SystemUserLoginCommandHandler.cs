using Confitec.Technical.Test.Domain.SystemUserModule;
using Confitec.Technical.Test.Infra.Crosscutting.Auth;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;

namespace Confitec.Technical.Test.Application.SystemUserModule.Login
{
    public class SystemUserLoginCommandHandler : IRequestHandler<SystemUserLoginCommand, SystemUserLoginModel>
    {
        private readonly IJwtOptions _jwtOptions;
        private readonly ISystemUserRepository _systemUserRepository;

        public SystemUserLoginCommandHandler(
            IJwtOptions jwtOptions,
            ISystemUserRepository systemUserRepository)
        {
            _jwtOptions = jwtOptions;
            _systemUserRepository = systemUserRepository;
        }

        public async Task<SystemUserLoginModel> Handle(SystemUserLoginCommand request, CancellationToken cancellationToken)
        {
            var systemUser = await _systemUserRepository.GetAsync(SystemUserSpecification.ByUserNameOrMail(request.Login));
            if (systemUser == null) { throw new InvalidDataException("User not found!"); }

            systemUser.DoLogin(request.Password);

            var identity = GetClaimsIdentity(systemUser);

            var handler = new JwtSecurityTokenHandler();
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Subject = identity,
                Issuer = _jwtOptions.Issuer,
                Audience = _jwtOptions.Audience,
                IssuedAt = _jwtOptions.IssuedAt,
                NotBefore = _jwtOptions.NotBefore,
                Expires = _jwtOptions.AccessTokenExpiration,
                SigningCredentials = _jwtOptions.SigningCredentials
            });

            var accessToken = handler.WriteToken(securityToken);
            var expiresIn = CalculateExpiresIn(securityToken.ValidFrom);
            ;
            return new SystemUserLoginModel(accessToken, expiresIn);
        }

        private ClaimsIdentity GetClaimsIdentity(SystemUser systemUser)
        {
            return new ClaimsIdentity
            (
                new GenericIdentity(systemUser.UserName),
                new[] {
                    new Claim("TokenID", Guid.NewGuid().ToString()),
                    new Claim("ID", systemUser.ID.ToString()),
                }
            );
        }

        private long CalculateExpiresIn(DateTime securityTokenValidFrom)
        {
            var differenceInSecondsBetweenUtcNowAndValidFrom = (DateTimeOffset.UtcNow - securityTokenValidFrom).TotalSeconds;
            var expirationSeconds = TimeSpan.FromMinutes(_jwtOptions.ExpirationMinutes).TotalSeconds;

            return Convert.ToInt64(expirationSeconds - differenceInSecondsBetweenUtcNowAndValidFrom);
        }
    }
}
