using AutoMapper;
using day5.DTOs;
using day5.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace day5.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDto>()
                .ForMember(
                    dest => dest.DepartmentName,
                    opt => opt.MapFrom(src => src.Department.Name)
                );
        }
    }
}
