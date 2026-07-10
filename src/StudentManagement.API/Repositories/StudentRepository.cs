using StudentManagement.Models;

namespace StudentManagement.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly List<Student> _students =
    [
        new Student
        {
            Id = 1,
            FirstName = "Prachi",
            LastName = "Mittal",
            Email = "prachi@test.com",
            Age = 28
        },
        new Student
        {
            Id = 2,
            FirstName = "John",
            LastName = "Doe",
            Email = "john@test.com",
            Age = 22
        }
    ];

    public List<Student> GetAll()
    {
        return _students;
    }
}