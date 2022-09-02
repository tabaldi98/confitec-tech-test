using MediatR;

namespace Confitec.Technical.Test.Application.UserModule.UserRetrieve
{
    public class UserRetrieveQuery : IRequest<IEnumerable<UserRetrieveModel>>
    { }
}
