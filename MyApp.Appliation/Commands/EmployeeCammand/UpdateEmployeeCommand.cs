using MediatR;
using MyApp.Appliation.DTO;
using MyApp.Appliation.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Appliation.Commands.EmployeeCammand
{

    public record UpdateEmployeeCommand(EmployeeDto emp) : IRequest<string>
    {
    }
    public class UpdateEmployeeCommandHandller(IMyEmployeeReposetory myEmployeeReposetory) : IRequestHandler<UpdateEmployeeCommand, string>
    {
        public Task<string> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var result = myEmployeeReposetory.UpdateEmployee(request.emp);
            return result;
        }
    }
}
