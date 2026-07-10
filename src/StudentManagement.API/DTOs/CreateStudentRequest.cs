using System.ComponentModel.DataAnnotations;

namespace StudentManagement.DTOs;

public class CreateStudentRequest
{
    [Required]
    [StringLength(50)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string LastName { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Range(5,100)]
    public int Age { get; set; }
}