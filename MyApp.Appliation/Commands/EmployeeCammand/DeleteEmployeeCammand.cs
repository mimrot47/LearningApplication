using MediatR;
using MyApp.Appliation.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Appliation.Commands.EmployeeCammand
{
    public record DeleteEmployeeCommand(int empId) : IRequest<string>
    {
        public class DeleteEmployeeCommandHandler(IMyEmployeeReposetory myEmployeeReposetory) : IRequestHandler<DeleteEmployeeCommand, string>
        {
            public async Task<string> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
            {
                var result = await myEmployeeReposetory.DeleteEmployee(request.empId);
                return result;
            }
        }
    }
}
