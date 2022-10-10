using UdemyApi.Model.Course;

namespace UdemyApi.Model.Department
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CourseDto> Courses { get; set; }
    }
}
