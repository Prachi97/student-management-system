using Microsoft.EntityFrameworkCore;
using StudentManagement.Data;
using StudentManagement.Models;

namespace StudentManagement.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly ApplicationDbContext _context;

    public StudentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Student>> GetAll()
    {
        return await _context.Students.ToListAsync();
    }

    public async Task<Student?> GetById(int id)
    {
        return await _context.Students.FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task Add(Student student)
    {
        _context.Students.Add(student);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Student student)
    {
        _context.Students.Update(student);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var student = await _context.Students.FirstOrDefaultAsync(s => s.Id == id);

        if (student == null)
            return;

        _context.Students.Remove(student);
        await _context.SaveChangesAsync();
    }
}