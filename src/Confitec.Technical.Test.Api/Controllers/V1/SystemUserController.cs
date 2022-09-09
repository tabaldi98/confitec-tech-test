using Confitec.Technical.Test.Application.SystemUserModule.Create;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Confitec.Technical.Test.Api.Controllers.V1
{
    [ApiController]
    [Authorize]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class SystemUserController : Controller
    {
        private readonly IMediator _mediator;

        public SystemUserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("")]
        [Produces("application/json")]
        public async Task<IActionResult> CreateAsync(SystemUserCreateCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
