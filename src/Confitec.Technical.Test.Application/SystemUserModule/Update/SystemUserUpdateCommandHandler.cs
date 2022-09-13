using Confitec.Technical.Test.Domain.SystemUserModule;
using Confitec.Technical.Test.Domain.SystemUserModule.Permissions;
using Confitec.Technical.Test.Infra.Crosscutting.Auth;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Confitec.Technical.Test.Application.SystemUserModule.Update
{
    public class SystemUserUpdateCommandHandler : IRequestHandler<SystemUserUpdateCommand, bool>
    {
        private readonly ISystemUserRepository _systemUserRepository;

        public SystemUserUpdateCommandHandler(ISystemUserRepository systemUserRepository)
        {
            _systemUserRepository = systemUserRepository;
        }

        public async Task<bool> Handle(SystemUserUpdateCommand request, CancellationToken cancellationToken)
        {
            if (request.ID == SystemUser.DefaultUser().ID) { throw new InvalidDataException("Not allowed update this User!"); }

            var systemUser = await _systemUserRepository.GetAsync(SystemUserSpecification.ById(request.ID), true, x => x.Permissions);
            if (systemUser == null) { throw new InvalidDataException("User not found!"); }

            systemUser.SetAproved(request.IsAproved);
            systemUser.Permissions.Clear();

            foreach (var permission in request.Permissions)
            {
                switch (permission)
                {
                    case Roles.CanManageObjects:
                        systemUser.AddPermission(new Permission(Roles.CanManageObjects, systemUser));
                        break;
                    case Roles.CanChangeGeneralSettings:
                        systemUser.AddPermission(new Permission(Roles.CanChangeGeneralSettings, systemUser));
                        break;
                    case Roles.CanManageSystemUsers:
                        systemUser.AddPermission(new Permission(Roles.CanManageSystemUsers, systemUser));
                        break;
                }
            }

            await _systemUserRepository.UpdateAsync(systemUser);

            return true;
        }
    }
}
