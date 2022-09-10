using Confitec.Technical.Test.Application.UserModule.UserRetrieve;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace Confitec.Technical.Test.Api.Controllers.V1.OData
{
    [Authorize]
    public class UsersODataController : ODataController
    {
        private readonly IMediator _mediator;

        public UsersODataController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [EnableQuery]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _mediator.Send(new UserRetrieveODataQuery()));
        }
    }
}
