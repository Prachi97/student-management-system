using Microsoft.AspNetCore.Mvc;
using StudentManagement.Models;
using StudentManagement.Services;
using StudentManagement.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Authentication;

namespace StudentManagement.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class AuthController : ControllerBase
{
    private readonly JwtService _jwtService;

    public AuthController(JwtService jwtService)
    {
        _jwtService = jwtService;
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        if (request.Username != "admin"
            || request.Password != "password")
        {
            return Unauthorized();
        }

        var token = _jwtService.GenerateToken(request.Username);

        return Ok(new LoginResponse
        {
            Token = token
        });
    }
}
namespace StudentManagement.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;

    private readonly IMapper _mapper;

    public StudentController(
        IStudentService studentService,
        IMapper mapper)
    {
        _studentService = studentService;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetStudents()
    {
        var students = _studentService.GetStudents();

        var response = _mapper.Map<List<StudentResponse>>(students);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public IActionResult GetStudent(int id)
    {
        var student = _studentService.GetStudentById(id);

        if (student == null)
            return NotFound();

        return Ok(student);
    }

    [HttpPost]
    public IActionResult AddStudent(CreateStudentRequest request)
    {
        var student = _mapper.Map<Student>(request);
        _studentService.AddStudent(student);
        return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateStudent(int id, UpdateStudentRequest request)
    {
        var student = new Student
        {
            Id = id,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Age = request.Age
        };

        _studentService.UpdateStudent(student);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteStudent(int id)
    {
        _studentService.DeleteStudent(id);

        return NoContent();
    }
}