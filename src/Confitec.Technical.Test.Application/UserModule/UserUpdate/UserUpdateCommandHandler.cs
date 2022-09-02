using Confitec.Technical.Test.Domain.UserModule;
using MediatR;

namespace Confitec.Technical.Test.Application.UserModule.UserUpdate
{
    public class UserUpdateCommandHandler : IRequestHandler<UserUpdateCommand, bool>
    {
        private readonly IUserRepository _userRepository;

        public UserUpdateCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(UserUpdateCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(UserSpecification.ById(request.ID), true);
            if (user == null) { throw new InvalidDataException("User not found!"); }

            var userAlreadyAdded = await _userRepository.AnyAsync(UserSpecification.ByNameAndSurNameAndId(request.Name, request.Surname, request.ID));
            if (userAlreadyAdded) { throw new InvalidDataException("User already added!"); }

            user.SetFullName(request.Name, request.Surname);
            user.SetMail(request.Mail);
            user.SetBirthDate(request.BirthDate);
            user.SetScholarity(request.Scholarity);

            return await _userRepository.UpdateAsync(user);
        }
    }
}
