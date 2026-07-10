using StudentManagement.Models;

namespace StudentManagement.Services;

public interface IStudentService
{
    List<Student> GetStudents();

    Student? GetStudentById(int id);

    void AddStudent(Student student);

    void UpdateStudent(Student student);

    void DeleteStudent(int id);
}