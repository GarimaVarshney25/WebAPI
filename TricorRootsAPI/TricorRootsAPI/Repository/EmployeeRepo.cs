using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using TricorRootsAPI.Repository.Query;
using TricorRootsAPI.Models;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace TricorRootsAPI.Repository
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly IQuery _cmdText;
        private readonly string _connStr;
        public EmployeeRepo(IConfiguration config, IQuery cmdText)
        {
            _cmdText = cmdText;
            _connStr = config.GetConnectionString("TricorConStr");
        }


        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();
            using (var conn = new SqlConnection(_connStr))
            {
               // conn.Open();
                employees = conn.Query<Employee>(_cmdText.GetEmployees).ToList();
                
            }
            return employees;
        }
        public Employee GetEmployeeDetails(int id)
        {
            var employee = new Employee();
            using(var conn = new SqlConnection(_connStr))
            {
                //conn.Open();
                //employee = conn.Query<Employee>(_cmdText.GetEmployeeDetails, new { @empId = id }).SingleOrDefault();
                employee = conn.QueryFirstOrDefault<Employee>(_cmdText.GetEmployeeDetails, new { @empId = id });
              
            }

            return employee;
        }
        public void AddEmployee(Employee entity)
        {
            using (var conn = new SqlConnection(_connStr))
            {
                //conn.Open();
                //conn.Query<Employee>(_cmdText.AddEmployee, new { @firstName = entity.firstName, @lastName = entity.lastName, @gender = entity.gender, @age = entity.age, @joinedDate = entity.joinedDate });
                conn.Execute(_cmdText.AddEmployee, new { @firstName = entity.firstName, @lastName = entity.lastName, @gender = entity.gender, @age = entity.age, @joinedDate = entity.joinedDate });
              
            }
        }
        public void UpdateEmployee(Employee entity, int id)
        {
            using (var conn = new SqlConnection(_connStr))
            {
                //conn.Open();
                //conn.Query<Employee>(_cmdText.UpdateEmployee, new { @firstName = entity.firstName, @lastName = entity.lastName, @gender = entity.gender, @age = entity.age, @joinedDate = entity.joinedDate, @empId=id });
                conn.Execute(_cmdText.UpdateEmployee, new { @firstName = entity.firstName, @lastName = entity.lastName, @gender = entity.gender, @age = entity.age, @joinedDate = entity.joinedDate, @empId = id });
               
            }
        }

        public void RemoveEmployee(int id)
        {
            using(var conn= new SqlConnection(_connStr))
            {
                //conn.Open();
                //conn.Query<Employee>(_cmdText.RemoveEmployee, new { @empId = id });
                conn.Execute(_cmdText.RemoveEmployee, new { @empId = id });
               
            }
        }      
    }
   
}
