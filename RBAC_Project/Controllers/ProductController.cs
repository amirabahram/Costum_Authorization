using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RBAC.Application.Features.Commands.CreateEvent;
using RBAC.Application.Features.Commands.DeleteEvent;
using RBAC.Application.Features.Commands.UpdateEvent;
using RBAC.Application.Features.Queries.GetAllEvent;

namespace RBAC.Api.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public readonly IMediator mediator;
        public ProductController(IMediator mediator) => this.mediator = mediator;


        [HttpGet("Get-All")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await mediator.Send(new GetAllProductsQueryRequest()));
        }

        [HttpPost("Create-Product")]
        [Authorize]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommandRequest request)
        {
            var result =await mediator.Send(request);
            if (result.IsSucceed == false)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
        [HttpPost("Add-Role-To-Product")]
        public async Task<IActionResult> AddRole([FromBody] AddRoleToProductRequest request)
        {
            var result = await mediator.Send(request);
            if(result.IsSucceed == false) return BadRequest(result.Message);
            return Ok(result);
        }
        [HttpDelete("ID")]
        //[Authorize("MustBeCreatorOfProduct")]
        [Authorize("MustBeCreatorOfProductOrDynamicRole")]
        public async Task<IActionResult> DeleteProduct([FromBody] DeleteProductCommandRequest request)
        {
            var result = await mediator.Send(request);
            if(result.IsSucceed == false) return BadRequest(result.Message);
            return Ok(result);
        }
        
        [HttpPut("Update-Product")]
        
        [Authorize("MustBeCreatorOfProductOrDynamicRole")]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductCommandRequest request)
        {
            var result = await mediator.Send(request);
            if (result.IsSucceed == false) return BadRequest(result.Message);
            return Ok(result);
        }
    }
}
