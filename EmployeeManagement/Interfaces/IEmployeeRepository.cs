using EmployeeManagement.Models;

namespace EmployeeManagement.Interfaces
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAll();
        Employee GetById(int id);

        Employee UpdateEmployeeDetails(int id,Employee employee);

        Employee Delete(int  id);

        Employee AddNewEmployee(Employee employee);

    }
}
