using Confitec.Technical.Test.Domain.SystemUserModule;
using MediatR;

namespace Confitec.Technical.Test.Application.SystemUserModule.RetrieveOData
{
    public class SystemUserRetrieveODataQueryHandler : IRequestHandler<SystemUserRetrieveODataQuery, IQueryable<SystemUserRetrieveODataModel>>
    {
        private readonly ISystemUserRepository _systemUserRepository;

        public SystemUserRetrieveODataQueryHandler(ISystemUserRepository systemUserRepository)
        {
            _systemUserRepository = systemUserRepository;
        }

        public async Task<IQueryable<SystemUserRetrieveODataModel>> Handle(SystemUserRetrieveODataQuery request, CancellationToken cancellationToken)
        {
            return _systemUserRepository.RetrieveOData(new SystemUserRetrieveODataModelMapper());
        }
    }
}
