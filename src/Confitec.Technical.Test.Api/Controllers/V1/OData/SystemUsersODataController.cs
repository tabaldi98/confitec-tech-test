using Confitec.Technical.Test.Application.SystemUserModule.RetrieveOData;
using Confitec.Technical.Test.Application.UserModule.UserRetrieve;
using Confitec.Technical.Test.Infra.Crosscutting.Auth;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace Confitec.Technical.Test.Api.Controllers.V1.OData
{
    [Authorize(Roles = Roles.CanManageSystemUsers)]
    public class SystemUsersODataController : ODataController
    {
        private readonly IMediator _mediator;

        public SystemUsersODataController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [EnableQuery]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _mediator.Send(new SystemUserRetrieveODataQuery()));
        }
    }
}
