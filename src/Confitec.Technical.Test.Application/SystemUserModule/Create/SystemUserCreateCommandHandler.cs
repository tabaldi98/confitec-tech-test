using Confitec.Technical.Test.Domain.SystemUserModule;
using Confitec.Technical.Test.Infra.Crosscutting.RabbitMq;
using MediatR;

namespace Confitec.Technical.Test.Application.SystemUserModule.Create
{
    public class SystemUserCreateCommandHandler : IRequestHandler<SystemUserCreateCommand, int>
    {
        private readonly IRabbitMqConnector _rabbitMqConnector;
        private readonly ISystemUserRepository _systemUserRepository;

        public SystemUserCreateCommandHandler(
            IRabbitMqConnector rabbitMqConnector,
            ISystemUserRepository systemUserRepository)
        {
            _rabbitMqConnector = rabbitMqConnector;
            _systemUserRepository = systemUserRepository;
        }

        public async Task<int> Handle(SystemUserCreateCommand request, CancellationToken cancellationToken)
        {
            var userAlreadyExists = await _systemUserRepository.AnyAsync(SystemUserSpecification.ByUserNameOrMail(request.UserName, request.Mail));
            if (userAlreadyExists) { throw new InvalidOperationException("User already exists"); }

            var systemUser = new SystemUser(request.FullName, request.UserName, request.Password, request.Mail);

            var systemUserCreated = await _systemUserRepository.CreateAsync(systemUser);

            _rabbitMqConnector.PublishMessage(new
            {
                AdminFullName = SystemUser.DefaultUser().FullName,
                AdminMail = SystemUser.DefaultUser().Mail,
                UserNameCreated = systemUserCreated.UserName,
                UserFullNameCreated = systemUserCreated.FullName,
                UserMailCreated = systemUserCreated.Mail,
            }, RabbitMqConstants.EXCHANGE_SYSTEM_USER_CREATED, RabbitMqConstants.ROUTING_KEY_SYSTEM_USER_CREATE);

            return systemUserCreated.ID;
        }
    }
}
