using Confitec.Technical.Test.Application.UserModule.UserCreate;
using Confitec.Technical.Test.Application.UserModule.UserUpdate;
using Confitec.Technical.Test.Domain.Contracts.Specification;
using Confitec.Technical.Test.Domain.UserModule;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace Confitec.Technical.Test.Tests.Application.UserModule
{
    [TestFixture]
    public class UserUpdateCommandHandlerTests : TestBase
    {
        private Mock<IUserRepository> _mockUserRepository;

        [SetUp]
        public void Setup()
        {
            _mockUserRepository = new Mock<IUserRepository>(MockBehavior.Strict);
        }

        [Test]
        public async Task Should_ReturnTrue_When_UpdateUser()
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
                .SetupVerifiable(p => p.GetAsync(It.Is<DirectSpecification<User>>(q => q.SatisfiedBy().Body.ToString() == UserSpecification.ById(id).SatisfiedBy().Body.ToString()), true))
                .ReturnsAsync(user);

            _mockUserRepository
                .SetupVerifiable(p => p.AnyAsync(It.Is<DirectSpecification<User>>(q => q.SatisfiedBy().Body.ToString() == UserSpecification.ByNameAndSurNameAndId(name, surName, id).SatisfiedBy().Body.ToString())))
                .ReturnsAsync(false);

            _mockUserRepository
                .SetupVerifiable(p => p.UpdateAsync(It.Is<User>(x =>
                    x.Name.Equals(name) &&
                    x.Surname.Equals(surName) &&
                    x.Mail.Equals(mail) &&
                    x.BirthDate == birthDate &&
                    x.Scholarity == scholarity &&
                    x.ID == id
                    )))
                .ReturnsAsync(true);

            // Act
            var result = await GetHandler().Handle(new UserUpdateCommand()
            {
                ID = id,
                Name = name,
                Surname = surName,
                Mail = mail,
                BirthDate = birthDate,
                Scholarity = scholarity,
            }, default);

            // Assert
            result.Should().BeTrue();

            CacheMockExtensions.VerifyAllCachedMocks();
        }

        [Test]
        public void Should_ReturnInvalidDataException_When_UpdateUser_And_UserNotFound()
        {
            // Arrange
            var id = Faker.Random.Int();

            _mockUserRepository
                .SetupVerifiable(p => p.GetAsync(It.Is<DirectSpecification<User>>(q => q.SatisfiedBy().Body.ToString() == UserSpecification.ById(id).SatisfiedBy().Body.ToString()), true))
                .ReturnsAsync(default(User));

            // Act
            var ex = Assert.ThrowsAsync<InvalidDataException>(() => GetHandler().Handle(new UserUpdateCommand()
            {
                ID = id
            }, default));

            // Assert
            ex.GetType().Should().Be<InvalidDataException>();
            ex.Message.Should().Be("User not found!");
            CacheMockExtensions.VerifyAllCachedMocks();
        }

        [Test]
        public void Should_ReturnInvalidDataException_When_UpdateUser_And_UserAlreadyExists()
        {
            // Arrange
            var command = new UserUpdateCommand()
            {
                ID = Faker.Random.Int(),
                Name = Faker.Person.FirstName,
                Surname = Faker.Person.LastName,
            };

            _mockUserRepository
                .SetupVerifiable(p => p.GetAsync(It.Is<DirectSpecification<User>>(q => q.SatisfiedBy().Body.ToString() == UserSpecification.ById(command.ID).SatisfiedBy().Body.ToString()), true))
                .ReturnsAsync(new User(command.Name, command.Surname, Faker.Person.Email, Faker.Person.DateOfBirth, UserScholarity.Medium));

            _mockUserRepository
                .SetupVerifiable(p => p.AnyAsync(It.Is<DirectSpecification<User>>(q => q.SatisfiedBy().Body.ToString() == UserSpecification.ByNameAndSurNameAndId(command.Name, command.Surname, command.ID).SatisfiedBy().Body.ToString())))
                .ReturnsAsync(true);

            // Act
            var ex = Assert.ThrowsAsync<InvalidDataException>(() => GetHandler().Handle(command, default));

            // Assert
            ex.GetType().Should().Be<InvalidDataException>();
            ex.Message.Should().Be("User already added!");
            CacheMockExtensions.VerifyAllCachedMocks();
        }

        private UserUpdateCommandHandler GetHandler()
        {
            return new UserUpdateCommandHandler(_mockUserRepository.Object);
        }
    }
}
