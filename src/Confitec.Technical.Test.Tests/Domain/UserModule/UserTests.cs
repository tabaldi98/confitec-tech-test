using Confitec.Technical.Test.Domain.UserModule;
using FluentAssertions;
using NUnit.Framework;

namespace Confitec.Technical.Test.Tests.Domain.UserModule
{
    [TestFixture]
    public class UserTests : TestBase
    {
        [Test]
        public void Should_CreateUser_When_UseConstructor()
        {
            // Arrange
            var name = Faker.Person.FirstName;
            var surName = Faker.Person.LastName;
            var birthDate = Faker.Person.DateOfBirth;
            var mail = Faker.Person.Email;
            var scholarity = UserScholarity.Infantile;
            var id = Faker.Random.Int();

            // Act
            var user = new User(name, surName, mail, birthDate, scholarity) { ID = id };

            // Assert
            user.Name.Should().Be(name);
            user.Surname.Should().Be(surName);
            user.Mail.Should().Be(mail);
            user.BirthDate.Should().Be(birthDate);
            user.Scholarity.Should().Be(scholarity);
            user.ID.Should().Be(id);
        }

        [Test]
        public void Should_UpdateUser_When_SetFullName()
        {
            // Arrange
            var newName = Faker.Person.FirstName;
            var newSurName = Faker.Person.LastName;

            var user = new User(Faker.Person.FirstName, Faker.Person.LastName, Faker.Person.Email, Faker.Person.DateOfBirth, UserScholarity.Infantile);

            // Act
            user.SetFullName(newName, newSurName);

            // Assert
            user.Name.Should().Be(newName);
            user.Surname.Should().Be(newSurName);
        }

        [Test]
        public void Should_UpdateUser_When_SetMail()
        {
            // Arrange
            var newMail = Faker.Person.Email;

            var user = new User(Faker.Person.FirstName, Faker.Person.LastName, Faker.Person.Email, Faker.Person.DateOfBirth, UserScholarity.Infantile);

            // Act
            user.SetMail(newMail);

            // Assert
            user.Mail.Should().Be(newMail);
        }

        [Test]
        public void Should_UpdateUser_When_SetBirthDate()
        {
            // Arrange
            var newBirthDate = Faker.Person.DateOfBirth;

            var user = new User(Faker.Person.FirstName, Faker.Person.LastName, Faker.Person.Email, Faker.Person.DateOfBirth, UserScholarity.Infantile);

            // Act
            user.SetBirthDate(newBirthDate);

            // Assert
            user.BirthDate.Should().Be(newBirthDate);
        }

        [Test]
        public void Should_UpdateUser_When_SetScholarity()
        {
            // Arrange
            var newScholarity= UserScholarity.Fundamental; 

            var user = new User(Faker.Person.FirstName, Faker.Person.LastName, Faker.Person.Email, Faker.Person.DateOfBirth, UserScholarity.Infantile);

            // Act
            user.SetScholarity(newScholarity);

            // Assert
            user.Scholarity.Should().Be(newScholarity);
        }
    }
}
