using Confitec.Technical.Test.Domain.SystemUserModule;
using MediatR;

namespace Confitec.Technical.Test.Application.SystemUserModule.UpdatePassword
{
    public class UpdatePasswordCommandHandler : IRequestHandler<UpdatePasswordCommand, bool>
    {
        private readonly ISystemUserRepository _systemUserRepository;

        public UpdatePasswordCommandHandler(ISystemUserRepository systemUserRepository)
        {
            _systemUserRepository = systemUserRepository;
        }

        public async Task<bool> Handle(UpdatePasswordCommand request, CancellationToken cancellationToken)
        {
            var systemUser = await _systemUserRepository.GetAsync(SystemUserSpecification.ById(request.UserId), true);
            if (systemUser == null) { throw new InvalidDataException("User not found!"); }

            systemUser.UpdatePass(request.Password, request.CurrentPassword);

            await _systemUserRepository.UpdateAsync(systemUser);

            return true;
        }
    }
}
