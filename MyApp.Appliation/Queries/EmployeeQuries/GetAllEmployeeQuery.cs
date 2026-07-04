using MediatR;
using MyApp.Appliation.DTO;
using MyApp.Appliation.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Appliation.Queries.EmployeeQuries
{
    public record GetAllEmployeeQuery : IRequest<List<EmployeeDto>>;

    public class GetAllEmployeeQueryHandller(IMyEmployeeReposetory reposetory) : IRequestHandler<GetAllEmployeeQuery, List<EmployeeDto>>
    {
        public Task<List<EmployeeDto>> Handle(GetAllEmployeeQuery request, CancellationToken cancellationToken)
        {
            return reposetory.GetEmployees();
        }
    }
}
