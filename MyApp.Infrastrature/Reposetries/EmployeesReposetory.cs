using Microsoft.EntityFrameworkCore;
using MyApp.Appliation.DTO;
using MyApp.Appliation.Interfaces;
using MyApp.Domain.Entity;
using MyApp.Infrastrature.Percestency;

namespace MyApp.Infrastrature.Reposetries
{
     public class EmployeesReposetory(MyAppDbcontext context): IMyEmployeeReposetory

    {
        public async Task<List<EmployeeDto>> GetEmployees()
        {
            var result = await context.MyEmployees.Select(x=> new EmployeeDto {
                Id=x.Id, Name=x.Name,
                Description = x.Description,
                Email = x.Email
            }).ToListAsync();
            return result;
        }

        public async Task<EmployeeDto> GetEmployeeById(int id)
        {

            var result = await context.MyEmployees.Select(x => new EmployeeDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Email = x.Email
            }).FirstOrDefaultAsync(x=>x.Id ==id);

            return result;
        }

        public async Task<string> AddEmployee(EmployeeDto empdto)
        {
            await context.MyEmployees.AddAsync(new MyEnployees
            {
                Name = empdto.Name,
                Description = empdto.Description,
                Email = empdto.Email,
            }
                );
            await context.SaveChangesAsync();

            return "Employee added successfully";
        }

        public async Task<string> UpdateEmployee(EmployeeDto employee)
        {
            var existUser = await context.MyEmployees.FindAsync(employee.Id);
            existUser.Email = string.IsNullOrWhiteSpace(employee.Email) ? existUser.Email : employee.Email;
            existUser.Name = string.IsNullOrWhiteSpace(employee.Name) ? existUser.Name : employee.Name;
            existUser.Description = string.IsNullOrWhiteSpace(employee.Description) ? existUser.Description : employee.Description;
            context.MyEmployees.Update(existUser);
            await context.SaveChangesAsync();

            return "Employee updated successfully";

        }

        public async Task<string> DeleteEmployee(int id)
        {
            var employee = await context.MyEmployees.FindAsync(id);
            if(employee != null) {
            context.MyEmployees.Remove(employee);
             context.SaveChanges();
            }
            return "Employee deleted successfully";
        }
}
}
