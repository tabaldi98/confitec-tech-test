using Confitec.Technical.Test.Domain.UserModule;
using MediatR;

namespace Confitec.Technical.Test.Application.UserModule.UserRetrieve
{
    public class UserRetrieveODataQueryHandler : IRequestHandler<UserRetrieveODataQuery, IQueryable<UserRetrieveODataModel>>
    {
        private readonly IUserRepository _userRepository;

        public UserRetrieveODataQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IQueryable<UserRetrieveODataModel>> Handle(UserRetrieveODataQuery request, CancellationToken cancellationToken)
        {
            return _userRepository.RetrieveOData(new UserRetrieveODataModelMapper());
        }
    }
}
