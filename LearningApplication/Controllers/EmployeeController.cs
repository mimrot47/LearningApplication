using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApp.Appliation.Commands.EmployeeCammand;
using MyApp.Appliation.DTO;
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
        [HttpPost("AddEmployees")]
        public async Task<IActionResult> AddEmployee([FromForm] EmployeeDto enpdata, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new AddEmployeeCommand(enpdata), cancellationToken);
            return Ok(result);
        }
        [HttpPut("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee([FromForm] EmployeeDto enpdata, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new UpdateEmployeeCommand(enpdata), cancellationToken);
            return Ok(result);
        }

        [HttpDelete("DeleteEmployee")]
        public async Task<IActionResult> DeleteEmployee(int empId, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new DeleteEmployeeCommand(empId), cancellationToken);
            return Ok(result);
        }
        [HttpGet("GetEmployeeID")]
        public async Task<IActionResult> GetEmployeeID(int empId, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new GetEmployeeByIdQuery(empId), cancellationToken);
            return Ok(result);
        }

    }
}
