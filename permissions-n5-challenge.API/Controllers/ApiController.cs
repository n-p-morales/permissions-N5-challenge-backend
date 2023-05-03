using System;
using Microsoft.AspNetCore.Mvc;

namespace permissions_n5_challenge.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApiController: ControllerBase
	{
		public ApiController()
		{
		}

        private readonly IMediator mediator;

        protected IMediator ApiMediator => this.mediator ?? this.HttpContext.RequestServices.GetService<IMediator>();

        public IActionResult Success(object response = null)
        {
            return this.Ok(HttpApiResponse.Ok(ResponseCode.Success, response));
        }

        public IActionResult InternalServerError(object response = null)
        {
            return this.StatusCode(500, HttpApiResponse.InternalServerError(ResponseCode.InternalError, response));
        }

        public IActionResult InvalidRequest(object response = null)
        {
            return this.BadRequest(HttpApiResponse.BadRequest(ResponseCode.ValidationError, response));
        }
    }
}

