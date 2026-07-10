using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.DTOs;
using StudentManagement.Models;
using StudentManagement.Services;

namespace StudentManagement.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
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
    public async Task<IActionResult> GetStudents()
    {
        var students = await _studentService.GetStudents();

        var response = _mapper.Map<List<StudentResponse>>(students);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetStudent(int id)
    {
        var student = await _studentService.GetStudentById(id);

        if (student == null)
            return NotFound();

        return Ok(student);
    }

    [HttpPost]
    public async Task<IActionResult> AddStudent(CreateStudentRequest request)
    {
        var student = _mapper.Map<Student>(request);
        await _studentService.AddStudent(student);
        return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateStudent(int id, UpdateStudentRequest request)
    {
        var student = new Student
        {
            Id = id,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Age = request.Age
        };

        await _studentService.UpdateStudent(student);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStudent(int id)
    {
        await _studentService.DeleteStudent(id);

        return NoContent();
    }
}