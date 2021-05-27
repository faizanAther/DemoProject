using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestCRUDDemoService.EmployeeData;
using RestCRUDDemoService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCRUDDemoService.Controllers
{

    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeData _employeeData;
        public EmployeeController(IEmployeeData employeeData)
        {
            _employeeData = employeeData;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetEmployees()
        {
            return Ok(_employeeData.GetEmployees());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetEmployee(Guid id)
        {
            var employee = _employeeData.GetEmployee(id);

            if (employee != null)
            {
                return Ok(_employeeData.GetEmployee(id));
            }
            else
            {
                return NotFound($"Employee With Id: {id} was not found");
            }
        }


        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddEmployee(Employee employee)
        {
            _employeeData.AddEmployee(employee);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + employee.Id,
                employee);

        }

        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public IActionResult EditEmployee(Guid id, Employee employee)
        {
            var emp = _employeeData.GetEmployee(id);
            if (emp != null)
            {
                employee.Id = emp.Id;
                _employeeData.EditEmployee(employee);
            }

            return Ok(employee);

        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var emp = _employeeData.GetEmployee(id);
            if (emp != null)
            {
                _employeeData.DeleteEmployee(emp);
                return Ok();
            }
            return NotFound($"Employee With Id: {id} was not found");
        }
    }
}
