using AutoMapper;
using WebApplication1.DTOs.Employees;
using WebApplication1.Models;

namespace WebApplication1.Utils
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() {
            CreateMap<EmployeeDTO, Employee>();
            CreateMap<Employee, EmployeeDTO>();
            CreateMap<EditEmployeeDTO, Employee>();
            CreateMap<PatchEmployeeDTO, Employee>();
        }
    }
}
