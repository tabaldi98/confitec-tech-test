using Confitec.Technical.Test.Application.UserModule.UserCreate;
using Confitec.Technical.Test.Application.UserModule.UserDelete;
using Confitec.Technical.Test.Domain.Contracts.Specification;
using Confitec.Technical.Test.Domain.UserModule;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace Confitec.Technical.Test.Tests.Application.UserModule
{
    [TestFixture]
    public class UserDeleteCommandHandlerTests : TestBase
    {
        private Mock<IUserRepository> _mockUserRepository;

        [SetUp]
        public void Setup()
        {
            _mockUserRepository = new Mock<IUserRepository>(MockBehavior.Strict);
        }

        [Test]
        public async Task Should_ReturnTrue_When_DeleteUser()
        {
            // Arrange
            var id = Faker.Random.Int();
            var user = new User(Faker.Person.FirstName, Faker.Person.LastName, Faker.Person.Email, Faker.Person.DateOfBirth, UserScholarity.Infantile)
            {
                ID = id,
            };

            _mockUserRepository
                .SetupVerifiable(p => p.GetAsync(It.Is<DirectSpecification<User>>(q => q.SatisfiedBy().Body.ToString() == UserSpecification.ById(id).SatisfiedBy().Body.ToString()), true))
                .ReturnsAsync(user);

            _mockUserRepository
                .SetupVerifiable(p => p.DeleteAsync(user))
                .ReturnsAsync(true);

            // Act
            var result = await GetHandler().Handle(new UserDeleteCommand(1), default);

            // Assert
            result.Should().BeTrue();

            CacheMockExtensions.VerifyAllCachedMocks();
        }

        [Test]
        public void Should_ReturnInvalidDataException_When_DeleteUser_And_UserNotFound()
        {
            // Arrange
            var id = Faker.Random.Int();

            _mockUserRepository
                .SetupVerifiable(p => p.GetAsync(It.Is<DirectSpecification<User>>(q => q.SatisfiedBy().Body.ToString() == UserSpecification.ById(id).SatisfiedBy().Body.ToString()), true))
                .ReturnsAsync(default(User));

            // Act
            var ex = Assert.ThrowsAsync<InvalidDataException>(() => GetHandler().Handle(new UserDeleteCommand(1), default));

            // Assert
            ex.GetType().Should().Be<InvalidDataException>();
            ex.Message.Should().Be("User not found");
            CacheMockExtensions.VerifyAllCachedMocks();
        }

        private UserDeleteCommandHandler GetHandler()
        {
            return new UserDeleteCommandHandler(_mockUserRepository.Object);
        }
    }
}
