using Confitec.Technical.Test.Domain.SystemUserModule;
using MediatR;

namespace Confitec.Technical.Test.Application.SystemUserModule.MyInformations
{
    public class SystemUserMyInformationsCommandHandler : IRequestHandler<SystemUserMyInformationsCommand, SystemUserMyInformationsModel>
    {
        private readonly ISystemUserRepository _systemUserRepository;

        public SystemUserMyInformationsCommandHandler(ISystemUserRepository systemUserRepository)
        {
            _systemUserRepository = systemUserRepository;
        }

        public async Task<SystemUserMyInformationsModel> Handle(SystemUserMyInformationsCommand request, CancellationToken cancellationToken)
        {
            var systemUser = await _systemUserRepository.GetAsync(SystemUserSpecification.ById(request.ID), false, p => p.Permissions);

            var permissions = systemUser.Permissions.Select(p => p.Role);

            return new SystemUserMyInformationsModel()
            {
                ID = systemUser.ID,
                CreateDate = systemUser.CreateDate,
                FullName = systemUser.FullName,
                LastLoginDate = systemUser.LastLoginDate,
                LastUpdatePasswordDate = systemUser.LastUpdatePasswordDate,
                Mail = systemUser.Mail,
                UserName = systemUser.UserName,
                Permissions = permissions,
                IsAproved = systemUser.IsAproved,
            };
        }
    }
}
