using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployees()
        {
            var employees = await _employeeService.GetAllEmployees();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(string id)
        {
            var employee = await _employeeService.GetEmployeeById(id);
            if (employee is null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _employeeService.CreateEmployee(employee);
            return Ok(employee);
        }

        public async Task<IActionResult> UpdateEmployee(string Id, Employee employee)
        {
            var checkEmployee = await _employeeService.GetEmployeeById(Id);
            if (checkEmployee is null)
            {
                return NotFound();
            }
            await _employeeService.UpdateEmployee(Id, employee);
            return Ok(employee);
        }

        public async Task<IActionResult> DeleteEmployee(string Id)
        {
            var checkEmployee = await _employeeService.GetEmployeeById(Id);
            if (checkEmployee is null)
            {
                return NotFound();
            }
            await _employeeService.GetEmployeeById(Id);
            return NoContent();
        }
    }
}
