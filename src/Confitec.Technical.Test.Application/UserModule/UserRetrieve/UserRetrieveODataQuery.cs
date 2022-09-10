using MediatR;

namespace Confitec.Technical.Test.Application.UserModule.UserRetrieve
{
    public class UserRetrieveODataQuery : IRequest<IQueryable<UserRetrieveODataModel>>
    { }
}
