using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FirstWebAPI.Models;

namespace FirstWebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class EmployeeController : ControllerBase
{
    private static List<Employee> employees = GetStandardEmployeeList();

    private static List<Employee> GetStandardEmployeeList()
    {
        return new List<Employee>
        {
            new Employee
            {
                Id = 1,
                Name = "Samuel",
                Salary = 50000,
                Permanent = true,
                Department = new Department
                {
                    Id = 1,
                    Name = "IT"
                },
                Skills = new List<Skill>
                {
                    new Skill{ Id=1, Name="C#" },
                    new Skill{ Id=2, Name="SQL" }
                },
                DateOfBirth = new DateTime(2002,1,1)
            },

            new Employee
            {
                Id = 2,
                Name = "John",
                Salary = 60000,
                Permanent = false,
                Department = new Department
                {
                    Id = 2,
                    Name = "HR"
                },
                Skills = new List<Skill>
                {
                    new Skill{ Id=3, Name="Java" }
                },
                DateOfBirth = new DateTime(2000,5,10)
            }
        };
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<List<Employee>> Get()
    {
        return Ok(employees);
    }

    [HttpPost]
    public ActionResult<Employee> Post([FromBody] Employee employee)
    {
        employees.Add(employee);

        return Ok(employee);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<Employee> Put(int id, [FromBody] Employee employee)
    {
        if (id <= 0)
        {
            return BadRequest("Invalid employee id");
        }

        var existingEmployee = employees.FirstOrDefault(e => e.Id == id);

        if (existingEmployee == null)
        {
            return BadRequest("Invalid employee id");
        }

        existingEmployee.Name = employee.Name;
        existingEmployee.Salary = employee.Salary;
        existingEmployee.Permanent = employee.Permanent;
        existingEmployee.Department = employee.Department;
        existingEmployee.Skills = employee.Skills;
        existingEmployee.DateOfBirth = employee.DateOfBirth;

        return Ok(existingEmployee);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Delete(int id)
    {
        if (id <= 0)
        {
            return BadRequest("Invalid employee id");
        }

        var employee = employees.FirstOrDefault(e => e.Id == id);

        if (employee == null)
        {
            return BadRequest("Invalid employee id");
        }

        employees.Remove(employee);

        return Ok("Employee Deleted Successfully");
    }
}