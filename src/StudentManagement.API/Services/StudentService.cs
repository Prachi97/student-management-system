using StudentManagement.Models;
using StudentManagement.Repositories;

namespace StudentManagement.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _repository;

    public StudentService(IStudentRepository repository)
    {
        _repository = repository;
    }

    public List<Student> GetStudents()
    {
        return _repository.GetAll();
    }
}