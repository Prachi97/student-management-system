using AutoMapper;
using StudentManagement.DTOs;
using StudentManagement.Models;

namespace StudentManagement.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateStudentRequest, Student>();

        CreateMap<UpdateStudentRequest, Student>();

        CreateMap<Student, StudentResponse>()
            .ForMember(
                dest => dest.FullName,
                opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}")
            );
    }
}