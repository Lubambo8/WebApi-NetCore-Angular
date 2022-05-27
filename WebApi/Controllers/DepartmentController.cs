using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
    public class DepartmentController : ControllerBase
    {
        private readonly DepartmentService _departmentService;
        private readonly EmployeeService _employeeService;

        public DepartmentController(DepartmentService departmentService, EmployeeService employeeService)
        {
            _departmentService = departmentService;
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetAllQuestions()
        {
            var departments = await _departmentService.GetAllDepartments();
            return Ok(departments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetQuestionById(string id)
        {
            var department = await _departmentService.GetDepartmentById(id);
            if (department is null)
            {
                return NotFound();
            }

            if (department.Employees.Count > 0)
            {
                var tempList = new List<Employee>();
                foreach (var employeedID in department.Employees)
                {
                    var employee = await _employeeService.GetEmployeeById(employeedID);
                    if (employee is not null)
                        tempList.Add(employee);
                }
                department.EmployeeList = tempList;
            }
            return Ok(department);
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuestion(Department department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _departmentService.CreateDepartment(department);
            return Ok(department);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuestion(string Id, Department department)
        {
            var checkDepartment = await _departmentService.GetDepartmentById(Id);
            if (checkDepartment is null)
            {
                return NotFound();
            }
            await _departmentService.UpdateDepartment(Id, department);
            return Ok(department);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(string Id)
        {
            var checkDepartment = await _departmentService.GetDepartmentById(Id);
            if (checkDepartment is null)
            {
                return NotFound();
            }
            await _departmentService.DeleteDepartment(Id);
            return NoContent();
        }

    }
}
