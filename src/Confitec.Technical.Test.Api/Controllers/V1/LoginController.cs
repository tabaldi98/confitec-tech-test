using Confitec.Technical.Test.Application.SystemUserModule.Login;
using Confitec.Technical.Test.Application.SystemUserModule.MyInformations;
using Confitec.Technical.Test.Application.SystemUserModule.RecoveryPassword;
using Confitec.Technical.Test.Application.SystemUserModule.RecoveryPasswordValidate;
using Confitec.Technical.Test.Application.SystemUserModule.RecoveryUpdatePassword;
using Confitec.Technical.Test.Application.SystemUserModule.UpdateMySelf;
using Confitec.Technical.Test.Application.SystemUserModule.UpdatePassword;
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

        [AllowAnonymous]
        [HttpPost]
        [Route("recovery-password")]
        [Produces("application/json")]
        public async Task<IActionResult> RecoveryPasswordAsync(SystemUserRecoveryPasswordCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("check-recovery-password")]
        [Produces("application/json")]
        public async Task<IActionResult> CheckRecoveryPasswordAsync(SystemUserRecoveryPasswordValidateCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [AllowAnonymous]
        [HttpPut]
        [Route("update-pass")]
        [Produces("application/json")]
        public async Task<IActionResult> UpdatePasswordOnRecoveryAsync(RecoveryUpdatePasswordCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [Authorize]
        [HttpPost]
        [Route("update-pass")]
        [Produces("application/json")]
        public async Task<IActionResult> UpdatePasswordAsync(UpdatePasswordCommand command)
        {
            command.UserId = int.Parse(HttpContext.User.Claims.FirstOrDefault(p => p.Type == "id").Value);
            return Ok(await _mediator.Send(command));
        }

        [Authorize]
        [HttpPut]
        [Route("update-myself")]
        [Produces("application/json")]
        public async Task<IActionResult> UpdateMySelfAsync(UpdateMySelfCommand command)
        {
            command.UserId = int.Parse(HttpContext.User.Claims.FirstOrDefault(p => p.Type == "id").Value);
            return Ok(await _mediator.Send(command));
        }

        [Authorize]
        [HttpGet]
        [Route("me")]
        [Produces("application/json")]
        public async Task<IActionResult> GetMyInformationsAsync()
        {
            return Ok(await _mediator.Send(new SystemUserMyInformationsCommand(int.Parse(HttpContext.User.Claims.FirstOrDefault(p => p.Type == "id").Value))));
        }
    }
}
