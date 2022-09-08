using Confitec.Technical.Test.Application.SystemUserModule.Login;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Confitec.Technical.Test.Api.Controllers.V1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class LoginController : Controller
    {
        private readonly IMediator _mediator;

        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("token")]
        [ProducesResponseType(typeof(SystemUserLoginModel), 200)]
        [Produces("application/json")]
        public async Task<IActionResult> LoginAsync(SystemUserLoginCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [Authorize]
        [HttpGet]
        [Route("is-alive")]
        [ProducesResponseType(typeof(bool), 200)]
        [Produces("application/json")]
        public IActionResult IsAlive()
        {
            return Ok(true);
        }
    }
}
