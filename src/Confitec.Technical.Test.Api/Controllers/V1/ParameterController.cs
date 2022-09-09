using Confitec.Technical.Test.Application.ParametersModule.Retrieve;
using Confitec.Technical.Test.Application.ParametersModule.Update;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Confitec.Technical.Test.Api.Controllers.V1
{
    [ApiController]
    [Authorize]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ParameterController : Controller
    {
        private readonly IMediator _mediator;

        public ParameterController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("{id:int}")]
        [Produces("application/json")]
        public async Task<IActionResult> GetAsync(int id)
        {
            return Ok(await _mediator.Send(new ParameterRetrieveCommand() { ID = id }));
        }

        [HttpGet]
        [Route("")]
        [Produces("application/json")]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _mediator.Send(new ParameterRetrieveAllCommand()));
        }

        [HttpPut]
        [Route("")]
        [Produces("application/json")]
        public async Task<IActionResult> UpdateAsync(ParameterUpdateCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
