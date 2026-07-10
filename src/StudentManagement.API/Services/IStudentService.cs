using StudentManagement.Models;

namespace StudentManagement.Services;

public interface IStudentService
{
    List<Student> GetStudents();
}