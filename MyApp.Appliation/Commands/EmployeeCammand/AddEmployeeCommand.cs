using MediatR;
using MyApp.Appliation.DTO;
using MyApp.Appliation.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Appliation.Commands.EmployeeCammand
{
    public record AddEmployeeCommand(EmployeeDto dto) : IRequest<string>;
    
    public class AddEmployeeCommandHandler(IMyEmployeeReposetory employeeReposetory):IRequestHandler<AddEmployeeCommand, string>
    {
        public async Task<string> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
            var result = await employeeReposetory.AddEmployee(request.dto);
            return result;
        }
    }
}
