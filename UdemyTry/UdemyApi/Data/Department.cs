namespace UdemyApi.Data
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual IList<Course> Courses { get; set; }

      

    }
}
