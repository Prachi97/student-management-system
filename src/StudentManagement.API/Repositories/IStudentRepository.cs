using StudentManagement.Models;

namespace StudentManagement.Repositories;

public interface IStudentRepository
{
    List<Student> GetAll();
}