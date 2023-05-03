using System;
using Microsoft.AspNetCore.Mvc;
using permissions_n5_challenge.Application.Commands.Permissions;
using permissions_n5_challenge.Application.Queries.Permissions;
using permissions_n5_challenge.Domain.Models.Permissions;

namespace permissions_n5_challenge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionsController: ApiController
	{
        [HttpGet("GetPermissionsById")]
        public async Task<IActionResult> GetPermissionsById(int Id)
        {
            return Success(await ApiMediator.Send(new GetPermissionsByIdQuery(Id)));
        }

        [HttpPost("CreatePermissions")]
        public async Task<IActionResult> CreatePermissions([FromBody] PermissionsModel relation)
        {
            return Success(await ApiMediator.Send(new CreatePermissionsCommand(relation)));
        }

        [HttpPut("UpdatePermissions")]
        public async Task<IActionResult> UpdatePermissions([FromBody] PermissionsModel relation)
        {
            return Success(await ApiMediator.Send(new UpdatePermissionsCommand(relation)));
        }
    }
}

