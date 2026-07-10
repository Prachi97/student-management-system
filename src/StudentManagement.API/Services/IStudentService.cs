using StudentManagement.Models;

namespace StudentManagement.Services;

public interface IStudentService
{
    Task<List<Student>> GetStudents();

    Task<Student?> GetStudentById(int id);

    Task AddStudent(Student student);

    Task UpdateStudent(Student student);

    Task DeleteStudent(int id);
}