using Confitec.Technical.Test.Application.UserModule.UserCreate;
using Confitec.Technical.Test.Application.UserModule.UserRetrieve;
using Confitec.Technical.Test.Application.UserModule.UserUpdate;
using Confitec.Technical.Test.Domain.Contracts.Specification;
using Confitec.Technical.Test.Domain.UserModule;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace Confitec.Technical.Test.Tests.Application.UserModule
{
    [TestFixture]
    public class UserRetrieveQueryHandlerTests : TestBase
    {
        private Mock<IUserRepository> _mockUserRepository;

        [SetUp]
        public void Setup()
        {
            _mockUserRepository = new Mock<IUserRepository>(MockBehavior.Strict);
        }

        [Test]
        public async Task Should_ReturnUsers_When_GetAllUsers()
        {
            // Arrange
            var name = Faker.Person.FirstName;
            var surName = Faker.Person.LastName;
            var birthDate = Faker.Person.DateOfBirth;
            var mail = Faker.Person.Email;
            var scholarity = UserScholarity.Infantile;
            var id = Faker.Random.Int();

            var user = new User(name, surName, mail, birthDate, scholarity)
            {
                ID = id,
            };

            _mockUserRepository
                .SetupVerifiable(p => p.GetAllAsync())
                .ReturnsAsync(new List<User>() { user });

            // Act
            var result = await GetHandler().Handle(new UserRetrieveODataQuery(), default);

            // Assert
            result.Should().ContainEquivalentOf(user);
            result.Count().Should().Be(1);

            CacheMockExtensions.VerifyAllCachedMocks();
        }

        private UserRetrieveODataQueryHandler GetHandler()
        {
            return new UserRetrieveODataQueryHandler(_mockUserRepository.Object);
        }
    }
}
