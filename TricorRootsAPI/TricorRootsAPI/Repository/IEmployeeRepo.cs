using System.Collections.Generic;
using TricorRootsAPI.Models;

namespace TricorRootsAPI.Repository
{
   public interface IEmployeeRepo
    {
        Employee GetEmployeeDetails(int id);
        void AddEmployee(Employee entity);
        void UpdateEmployee(Employee entity, int id);
        void RemoveEmployee(int id);
        List<Employee> GetAllEmployees();
    }
}
