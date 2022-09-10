using Confitec.Technical.Test.Api.Controllers.V1;
using Confitec.Technical.Test.Application.UserModule.UserCreate;
using Confitec.Technical.Test.Application.UserModule.UserDelete;
using Confitec.Technical.Test.Application.UserModule.UserRetrieve;
using Confitec.Technical.Test.Application.UserModule.UserUpdate;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace Confitec.Technical.Test.Tests.Api.V1
{
    [TestFixture]
    public class UserControllerTests
    {
        private Mock<IMediator> _mockMediator;
        private UserController _controller;

        [SetUp]
        public void Setup()
        {
            _mockMediator = new Mock<IMediator>(MockBehavior.Strict);
            _controller = new UserController(_mockMediator.Object);
        }

        [Test]
        public void Should_CheckAttributes_When_GetAllUsers()
        {
            //Assert
            typeof(UserController)
               .GetMethod(nameof(UserController.GetAllAsync))
               .Should()
               .BeDecoratedWith<HttpGetAttribute>().And
               .BeDecoratedWith<RouteAttribute>(p => p.Template.Equals(""));
        }

        [Test]
        public async Task Should_ReturnOK_When_GetAllUsers()
        {
            //Arrange
            _mockMediator
                .SetupVerifiable(p => p.Send(It.IsAny<UserRetrieveODataQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<UserRetrieveODataModel>());

            // Act
            var result = await _controller.GetAllAsync();

            // Assert
            var response = result.Should().BeOfType<OkObjectResult>().Subject.Value;
            response.Should().BeOfType<List<UserRetrieveODataModel>>();

            CacheMockExtensions.VerifyAllCachedMocks();
        }

        [Test]
        public void Should_CheckAttributes_When_CreateUser()
        {
            //Assert
            typeof(UserController)
               .GetMethod(nameof(UserController.CreateAsync))
               .Should()
               .BeDecoratedWith<HttpPostAttribute>().And
               .BeDecoratedWith<RouteAttribute>(p => p.Template.Equals(""));
        }

        [Test]
        public async Task Should_ReturnOK_When_CreateUser()
        {
            //Arrange
            var command = new UserCreateCommand();

            _mockMediator
                .SetupVerifiable(p => p.Send(command, It.IsAny<CancellationToken>()))
                .ReturnsAsync(1);

            // Act
            var result = await _controller.CreateAsync(command);

            // Assert
            var response = result.Should().BeOfType<OkObjectResult>().Subject.Value;
            response.Should().BeOfType<int>();

            CacheMockExtensions.VerifyAllCachedMocks();
        }

        [Test]
        public void Should_CheckAttributes_When_UpdateUser()
        {
            //Assert
            typeof(UserController)
               .GetMethod(nameof(UserController.UpdateAsync))
               .Should()
               .BeDecoratedWith<HttpPutAttribute>().And
               .BeDecoratedWith<RouteAttribute>(p => p.Template.Equals(""));
        }

        [Test]
        public async Task Should_ReturnOK_When_UpdateUser()
        {
            //Arrange
            var command = new UserUpdateCommand();

            _mockMediator
                .SetupVerifiable(p => p.Send(command, It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            // Act
            var result = await _controller.UpdateAsync(command);

            // Assert
            var response = result.Should().BeOfType<OkObjectResult>().Subject.Value;
            response.Should().BeOfType<bool>();

            CacheMockExtensions.VerifyAllCachedMocks();
        }

        [Test]
        public void Should_CheckAttributes_When_DeleteUser()
        {
            //Assert
            typeof(UserController)
               .GetMethod(nameof(UserController.DeleteAsync))
               .Should()
               .BeDecoratedWith<HttpDeleteAttribute>().And
               .BeDecoratedWith<RouteAttribute>(p => p.Template.Equals("{id:int}"));
        }

        [Test]
        public async Task Should_ReturnOK_When_DeleteUser()
        {
            //Arrange
            var command = new UserDeleteCommand(1);

            _mockMediator
                .SetupVerifiable(p => p.Send(It.IsAny<UserDeleteCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            // Act
            var result = await _controller.DeleteAsync(1);

            // Assert
            var response = result.Should().BeOfType<OkObjectResult>().Subject.Value;
            response.Should().BeOfType<bool>();

            CacheMockExtensions.VerifyAllCachedMocks();
        }
    }
}
