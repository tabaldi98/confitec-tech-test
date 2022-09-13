using Confitec.Technical.Test.Domain.SystemUserModule;
using MediatR;

namespace Confitec.Technical.Test.Application.SystemUserModule.Delete
{
    public class SystemUserDeleteCommandHandler : IRequestHandler<SystemUserDeleteCommand, bool>
    {
        private readonly ISystemUserRepository _systemUserRepository;

        public SystemUserDeleteCommandHandler(ISystemUserRepository systemUserRepository)
        {
            _systemUserRepository = systemUserRepository;
        }

        public async Task<bool> Handle(SystemUserDeleteCommand request, CancellationToken cancellationToken)
        {
            if (request.IDs.Contains(SystemUser.DefaultUser().ID)) { throw new InvalidDataException("Not allowed delete this User!"); }

            return await _systemUserRepository.DeleteManyAsync(request.IDs);
        }
    }
}
