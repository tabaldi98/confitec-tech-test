using Confitec.Technical.Test.Domain.UserModule;
using MediatR;

namespace Confitec.Technical.Test.Application.UserModule.UserGet
{
    public class UserGetCommandHandler : IRequestHandler<UserGetCommand, UserGetModel>
    {
        private readonly IUserRepository _userRepository;

        public UserGetCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserGetModel> Handle(UserGetCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(UserSpecification.ById(request.ID), false);
            if (user == null) { throw new InvalidDataException("User not found!"); }

            return new UserGetModel()
            {
                ID = user.ID,
                Name = user.Name,
                Surname = user.Surname,
                BirthDate = user.BirthDate,
                Mail = user.Mail,
                Scholarity = user.Scholarity,
            };
        }
    }
}
