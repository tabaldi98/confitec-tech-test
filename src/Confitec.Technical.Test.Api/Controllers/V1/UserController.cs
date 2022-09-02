using Confitec.Technical.Test.Application.UserModule.UserCreate;
using Confitec.Technical.Test.Application.UserModule.UserDelete;
using Confitec.Technical.Test.Application.UserModule.UserRetrieve;
using Confitec.Technical.Test.Application.UserModule.UserUpdate;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Confitec.Technical.Test.Api.Controllers.V1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UserController : Controller
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        [Produces("application/json")]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _mediator.Send(new UserRetrieveQuery()));
        }

        [HttpPost]
        [Route("")]
        [Produces("application/json")]
        public async Task<IActionResult> CreateAsync(UserCreateCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut]
        [Route("")]
        [Produces("application/json")]
        public async Task<IActionResult> UpdateAsync(UserUpdateCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Produces("application/json")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            return Ok(await _mediator.Send(new UserDeleteCommand(id)));
        }
    }
}
