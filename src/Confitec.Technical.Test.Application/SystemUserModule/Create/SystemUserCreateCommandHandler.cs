using Confitec.Technical.Test.Domain.SystemUserModule;
using MediatR;

namespace Confitec.Technical.Test.Application.SystemUserModule.Create
{
    public class SystemUserCreateCommandHandler : IRequestHandler<SystemUserCreateCommand, int>
    {
        private readonly ISystemUserRepository _systemUserRepository;

        public SystemUserCreateCommandHandler(ISystemUserRepository systemUserRepository)
        {
            _systemUserRepository = systemUserRepository;
        }

        public async Task<int> Handle(SystemUserCreateCommand request, CancellationToken cancellationToken)
        {
            var userAlreadyExists = await _systemUserRepository.AnyAsync(SystemUserSpecification.ByUserNameOrMail(request.UserName, request.Mail));
            if (userAlreadyExists) { throw new InvalidOperationException("User already exists"); }

            var systemUser = new SystemUser(request.FullName, request.UserName, request.Password, request.Mail);

            var systemUserCreated = await _systemUserRepository.CreateAsync(systemUser);

            return systemUserCreated.ID;
        }
    }
}
