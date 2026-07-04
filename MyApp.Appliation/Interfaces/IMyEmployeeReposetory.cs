using MyApp.Appliation.DTO;
using MyApp.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Appliation.Interfaces
{
    public interface IMyEmployeeReposetory
    {
        Task<List<EmployeeDto>> GetEmployees();

        Task<EmployeeDto> GetEmployeeById(int id);

        Task<string> AddEmployee(EmployeeDto employee);

        Task<string> UpdateEmployee(EmployeeDto employee);

        Task<string> DeleteEmployee(int id);



    }
}
