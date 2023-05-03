using System;
using Microsoft.AspNetCore.Mvc;
using permissions_n5_challenge.Application.Commands.PermissionsType;
using permissions_n5_challenge.Application.Queries.PermissionsType;
using permissions_n5_challenge.Domain.Models.PermissionsTypes;

namespace permissions_n5_challenge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionTypeController: ApiController
	{
        [HttpGet("GetPermissionsTypeById")]
        public async Task<IActionResult> GetPermissionsTypeById(int Id)
        {
            return Success(await ApiMediator.Send(new GetPermissionsTypeByIdQuery(Id)));
        }

        [HttpPost("CreatePermissionsType")]
        public async Task<IActionResult> CreatePermissionsType([FromBody] PermissionsTypeModel permissions)
        {
            return Success(await ApiMediator.Send(new CreatePermissionsTypeCommand(permissions)));
        }

        [HttpPut("UpdatePermissionsType")]
        public async Task<IActionResult> UpdatePermissionsType([FromBody] PermissionsTypeModel permissions)
        {
            return Success(await ApiMediator.Send(new UpdatePermissionsTypeCommand(permissions)));
        }
    }
}

