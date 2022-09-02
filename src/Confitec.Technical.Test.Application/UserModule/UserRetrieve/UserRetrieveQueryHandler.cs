using Confitec.Technical.Test.Domain.UserModule;
using MediatR;

namespace Confitec.Technical.Test.Application.UserModule.UserRetrieve
{
    public class UserRetrieveQueryHandler : IRequestHandler<UserRetrieveQuery, IEnumerable<UserRetrieveModel>>
    {
        private readonly IUserRepository _userRepository;

        public UserRetrieveQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserRetrieveModel>> Handle(UserRetrieveQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllAsync();

            return users.Select(p => new UserRetrieveModel()
            {
                ID = p.ID,
                Name = p.Name,
                Surname = p.Surname,
                Mail = p.Mail,
                BirthDate = p.BirthDate,
                Scholarity = p.Scholarity,
            });
        }
    }
}
