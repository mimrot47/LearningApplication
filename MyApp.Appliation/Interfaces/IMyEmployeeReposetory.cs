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

        Task<string> AddEmployee(MyEnployees employee);

        Task<string> UpdateEmployee(MyEnployees employee);

        Task<string> DeleteEmployee(int id);



    }
}
