using Confitec.Technical.Test.Application.UserModule.UserCreate;
using Confitec.Technical.Test.Domain.Contracts.Specification;
using Confitec.Technical.Test.Domain.UserModule;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace Confitec.Technical.Test.Tests.Application.UserModule
{
    [TestFixture]
    public class UserCreateCommandHandlerTests : TestBase
    {
        private Mock<IUserRepository> _mockUserRepository;

        [SetUp]
        public void Setup()
        {
            _mockUserRepository = new Mock<IUserRepository>(MockBehavior.Strict);
        }

        [Test]
        public async Task Should_ReturnValidID_When_CreateUser()
        {
            // Arrange
            var name = Faker.Person.FirstName;
            var surName = Faker.Person.LastName;
            var birthDate = Faker.Person.DateOfBirth;
            var mail = Faker.Person.Email;
            var scholarity = UserScholarity.Infantile;
            var id = Faker.Random.Int();

            _mockUserRepository
                .SetupVerifiable(p => p.AnyAsync(It.Is<DirectSpecification<User>>(q => q.SatisfiedBy().Body.ToString() == UserSpecification.ByNameAndSurName(name, surName).SatisfiedBy().Body.ToString())))
                .ReturnsAsync(false);

            _mockUserRepository
                .SetupVerifiable(p => p.CreateAsync(It.Is<User>(x =>
                    x.Name.Equals(name) &&
                    x.Surname.Equals(surName) &&
                    x.Mail.Equals(mail) &&
                    x.BirthDate == birthDate &&
                    x.Scholarity == scholarity
                    )))
                .ReturnsAsync(new User(name, surName, mail, birthDate, scholarity) { ID = id });

            // Act
            var result = await GetHandler().Handle(new UserCreateCommand()
            {
                Name = name,
                Surname = surName,
                Mail = mail,
                BirthDate = birthDate,
                Scholarity = scholarity,
            }, default);

            // Assert
            result.Should().Be(id);

            CacheMockExtensions.VerifyAllCachedMocks();
        }

        [Test]
        public void Should_ReturnInvalidOperationException_When_CreateUser_And_UserAlreadyExists()
        {
            // Arrange
            var name = Faker.Person.FirstName;
            var surName = Faker.Person.LastName;

            _mockUserRepository
                .SetupVerifiable(p => p.AnyAsync(It.Is<DirectSpecification<User>>(q => q.SatisfiedBy().Body.ToString() == UserSpecification.ByNameAndSurName(name, surName).SatisfiedBy().Body.ToString())))
                .ReturnsAsync(true);

            // Act
            var ex = Assert.ThrowsAsync<InvalidOperationException>(() => GetHandler().Handle(new UserCreateCommand()
            {
                Name = name,
                Surname = surName,
            }, default));

            // Assert
            ex.GetType().Should().Be<InvalidOperationException>();
            ex.Message.Should().Be("User already exists");
            CacheMockExtensions.VerifyAllCachedMocks();
        }

        private UserCreateCommandHandler GetHandler()
        {
            return new UserCreateCommandHandler(_mockUserRepository.Object);
        }
    }
}
