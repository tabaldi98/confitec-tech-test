using Confitec.Technical.Test.Application.UserModule.UserCreate;
using Confitec.Technical.Test.Application.UserModule.UserDelete;
using Confitec.Technical.Test.Application.UserModule.UserDeleteMany;
using Confitec.Technical.Test.Application.UserModule.UserGet;
using Confitec.Technical.Test.Application.UserModule.UserRetrieve;
using Confitec.Technical.Test.Application.UserModule.UserUpdate;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Confitec.Technical.Test.Api.Controllers.V1
{
    [ApiController]
    [Authorize]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UserController : Controller
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("{id:int}")]
        [Produces("application/json")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _mediator.Send(new UserGetCommand(id)));
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

        [HttpPost]
        [Route("deleteMany")]
        [Produces("application/json")]
        public async Task<IActionResult> DeleteManyAsync(UserDeleteManyCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
