using System.ComponentModel.DataAnnotations.Schema;

namespace UdemyApi.Data
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey (nameof(DepartmentId))]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
