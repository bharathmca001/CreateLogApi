using AutoMapper;
using UdemyApi.Data;
using UdemyApi.Model.Course;
using UdemyApi.Model.Department;

namespace UdemyApi.Configration
{
    public class AutoMaperConfig:Profile
    {
        public AutoMaperConfig()
        {
            CreateMap<Department, CreateDepartmentDto>().ReverseMap();
            CreateMap<Department, GetDepartmentDto>().ReverseMap();  
            CreateMap<Department,DepartmentDto>().ReverseMap();
            CreateMap<Department, UpdateDepartmentDto>().ReverseMap();


            CreateMap<Course, CourseDto>().ReverseMap();
        }
    }
}
