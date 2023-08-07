using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RBAC.Application.Features.Commands.CreateEvent;
using RBAC.Application.Features.Queries.GetAllEvent;

namespace RBAC.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await _mediator.Send(new GetAllUsersQueryRequest()));
        }


        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterUserRequest request)
        {
            var result = await _mediator.Send(request);
            if(result.Errors==null) return Ok(result);
            return BadRequest(result.Errors);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginUserCommandRequest request)
        {
           var result = await  _mediator.Send(request);
            if (result.Errors == null) return Ok(result);
            return BadRequest(result.Errors);
        }
        

        [HttpPost("Add-Role-To-User")]
        public async Task<IActionResult> AddRole(AddRoleCommandRequest request)
        {
            var result = await  _mediator.Send(request);
            return Ok(result);
        }
    }
}
