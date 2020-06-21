using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TricorRootsAPI.Repository;
using TricorRootsAPI.Models;
using Microsoft.AspNetCore.Cors;

namespace TricorRootsAPI.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepo _employeeRepo;

        public EmployeeController(IEmployeeRepo employeeRepository)
        {
            _employeeRepo = employeeRepository;
        }

        [HttpGet]
        public ActionResult<List<Employee>> GetAllEmployees()
        {
            var employees = _employeeRepo.GetAllEmployees();         
            return Ok(employees);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Employee> GetEmployeeDetails(int id)
        {
            var employee = _employeeRepo.GetEmployeeDetails(id);
            return Ok(employee);
        }
        [HttpPost]      
        public ActionResult AddEmployee([FromBody]Employee emp)
        {
            _employeeRepo.AddEmployee(emp);
            return Ok(emp);
        }
       
        [HttpPut]
        public ActionResult<Employee> Update([FromBody]Employee emp)
        {
            _employeeRepo.UpdateEmployee(emp, emp.empId);         
            return Ok(emp);
        }
        [HttpDelete("{id}")]
        public ActionResult<Employee> Delete(int id)
        {
            _employeeRepo.RemoveEmployee(id);

            return Ok();
        }
    }
}