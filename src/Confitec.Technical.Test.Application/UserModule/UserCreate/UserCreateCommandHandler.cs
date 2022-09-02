using Confitec.Technical.Test.Domain.UserModule;
using MediatR;

namespace Confitec.Technical.Test.Application.UserModule.UserCreate
{
    public class UserCreateCommandHandler : IRequestHandler<UserCreateCommand, int>
    {
        private readonly IUserRepository _userRepository;

        public UserCreateCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<int> Handle(UserCreateCommand request, CancellationToken cancellationToken)
        {
            var userAlreadyExists = await _userRepository.AnyAsync(UserSpecification.ByNameAndSurName(request.Name, request.Surname));
            if (userAlreadyExists) { throw new InvalidOperationException("User already exists"); }

            var user = new User(request.Name, request.Surname, request.Mail, request.BirthDate, request.Scholarity);

            var userCreated = await _userRepository.CreateAsync(user);

            return userCreated.ID;
        }
    }
}
