using EmployeeManagement.Contexts;
using EmployeeManagement.Interfaces;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;

namespace EmployeeManagement.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeContext context;

        public EmployeeRepository(EmployeeContext context)
        {
            this.context = context;
        }

        public Employee AddNewEmployee(Employee employee)
        {
            if (employee != null)
            { 
                context.Add(employee);
                context.SaveChanges();

                return employee;

            }
            else
            {
                  throw new NullReferenceException();
            }

            
        }

        public Employee Delete(int id)
        {
             var employee=GetById(id);
           context.Employees.Remove(employee);
            context.SaveChanges();
            return employee;
            
        }

        //public async Task<IEnumerable<Employee>> GetAllAsync() => await context.Employees.ToListAsync();
        public List<Employee> GetAll()
        {
            var employees = context.Employees.ToList();
           
            return employees;
        }

        public Employee GetById(int Id)
        {
            var employee = context.Employees.FirstOrDefault(x => x.Id == Id);
            
            return employee;
        }

        public Employee UpdateEmployeeDetails(int id,Employee employee)
        {
           
                if (id != employee.Id)
                {
                throw new NotImplementedException();
                 }

            context.Entry(employee).State = EntityState.Modified;

                try
                {
                     context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(id))
                    {
                    throw new NotImplementedException();
                }
                    else
                    {
                        throw;
                    }
                }

                return employee;
        }

        private bool EmployeeExists(int id)
        {
            var EmployeesController = GetAll();

            return EmployeesController.Any(e => e.Id == id);
        }

    }
}
