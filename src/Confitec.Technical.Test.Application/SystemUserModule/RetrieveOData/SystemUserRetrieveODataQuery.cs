using MediatR;

namespace Confitec.Technical.Test.Application.SystemUserModule.RetrieveOData
{
    public class SystemUserRetrieveODataQuery : IRequest<IQueryable<SystemUserRetrieveODataModel>>
    { }
}
