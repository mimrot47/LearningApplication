using MediatR;
using MyApp.Appliation.DTO;
using MyApp.Appliation.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Appliation.Queries.EmployeeQuries
{
    public record GetEmployeeByIdQuery(int Id) : IRequest<EmployeeDto>;
    public class GetEmployeeByIdQueryHandller(IMyEmployeeReposetory reposetory) : IRequestHandler<GetEmployeeByIdQuery, EmployeeDto>
    {
        public Task<EmployeeDto> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            return reposetory.GetEmployeeById(request.Id);
        }
    }
}
