using Confitec.Technical.Test.Domain.SystemUserModule;
using MediatR;

namespace Confitec.Technical.Test.Application.SystemUserModule.UpdateMySelf
{
    public class UpdateMySelfCommandHandler : IRequestHandler<UpdateMySelfCommand, bool>
    {
        private readonly ISystemUserRepository _systemUserRepository;

        public UpdateMySelfCommandHandler(ISystemUserRepository systemUserRepository)
        {
            _systemUserRepository = systemUserRepository;
        }

        public async Task<bool> Handle(UpdateMySelfCommand request, CancellationToken cancellationToken)
        {
            var systemUser = await _systemUserRepository.GetAsync(SystemUserSpecification.ById(request.UserId), true);
            if (systemUser == null) { throw new InvalidDataException("User not found!"); }

            systemUser.UpdateBasicInfo(request.FullName, request.Mail);

            await _systemUserRepository.UpdateAsync(systemUser);

            return true;
        }
    }
}
