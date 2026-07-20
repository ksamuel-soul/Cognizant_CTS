using Microsoft.AspNetCore.Mvc;
using FirstWebAPI.Models;

namespace FirstWebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    private static List<Student> students = new()
    {
        new Student
        {
            Id = 1,
            Name = "Samuel",
            Age = 22,
            Course = "C#"
        },
        new Student
        {
            Id = 2,
            Name = "John",
            Age = 23,
            Course = "Java"
        }
    };

    [HttpGet]
    public IActionResult GetStudents()
    {
        return Ok(students);
    }

    [HttpGet("{id}")]
    public IActionResult GetStudent(int id)
    {
        var student = students.FirstOrDefault(s => s.Id == id);

        if (student == null)
            return BadRequest("Student Not Found");

        return Ok(student);
    }

    [HttpPost]
    public IActionResult AddStudent(Student student)
    {
        students.Add(student);

        return Ok("Student Added Successfully");
    }

    [HttpPut("{id}")]
    public IActionResult UpdateStudent(int id, Student student)
    {
        var existing = students.FirstOrDefault(s => s.Id == id);

        if (existing == null)
            return BadRequest("Student Not Found");

        existing.Name = student.Name;
        existing.Age = student.Age;
        existing.Course = student.Course;

        return Ok("Student Updated Successfully");
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteStudent(int id)
    {
        var student = students.FirstOrDefault(s => s.Id == id);

        if (student == null)
            return BadRequest("Student Not Found");

        students.Remove(student);

        return Ok("Student Deleted Successfully");
    }

    [HttpGet("Unauthorized")]
    public IActionResult UnauthorizedDemo()
    {
        return Unauthorized();
    }

    [HttpGet("Error")]
    public IActionResult ErrorDemo()
    {
        return StatusCode(500, "Internal Server Error");
    }
}