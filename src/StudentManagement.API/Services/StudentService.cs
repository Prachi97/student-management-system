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

    public async Task<List<Student>> GetStudents()
    {
        return await _repository.GetAll();
    }

    public async Task<Student?> GetStudentById(int id)
    {
        return await _repository.GetById(id);
    }

    public async Task AddStudent(Student student)
    {
        await _repository.Add(student);
    }

    public async Task UpdateStudent(Student student)
    {
        await _repository.Update(student);
    }

    public async Task DeleteStudent(int id)
    {
        await _repository.Delete(id);
    }
}