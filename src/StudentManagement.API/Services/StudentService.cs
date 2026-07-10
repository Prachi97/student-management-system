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

    public Student? GetStudentById(int id)
    {
        return _repository.GetById(id);
    }

    public void AddStudent(Student student)
    {
        _repository.Add(student);
    }

    public void UpdateStudent(Student student)
    {
        _repository.Update(student);
    }

    public void DeleteStudent(int id)
    {
        _repository.Delete(id);
    }
}