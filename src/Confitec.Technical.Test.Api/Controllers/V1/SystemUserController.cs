using Confitec.Technical.Test.Application.SystemUserModule.Create;
using Confitec.Technical.Test.Application.SystemUserModule.Delete;
using Confitec.Technical.Test.Application.SystemUserModule.MyInformations;
using Confitec.Technical.Test.Application.SystemUserModule.Update;
using Confitec.Technical.Test.Infra.Crosscutting.Auth;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Confitec.Technical.Test.Api.Controllers.V1
{
    [ApiController]
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

        [Authorize(Roles = Roles.CanManageSystemUsers)]
        [HttpGet]
        [Route("{id:int}")]
        [Produces("application/json")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _mediator.Send(new SystemUserMyInformationsCommand(id)));
        }

        [Authorize(Roles = Roles.CanManageSystemUsers)]
        [HttpPut]
        [Route("")]
        [Produces("application/json")]
        public async Task<IActionResult> UpdateAsync(SystemUserUpdateCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [Authorize(Roles = Roles.CanManageSystemUsers)]
        [HttpPost]
        [Route("delete")]
        [Produces("application/json")]
        public async Task<IActionResult> DeleteManyAsync(SystemUserDeleteCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
