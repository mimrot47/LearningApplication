using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApp.Appliation.Queries.EmployeeQuries;

namespace LearningApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController(IMediator mediator) : ControllerBase
    {
        [HttpGet("GetAllEmployees")]
        public async Task<IActionResult> GetAllEmployees(CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new GetAllEmployeeQuery(), cancellationToken);
            return Ok(result);
        }

    }
}
