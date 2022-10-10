using Microsoft.EntityFrameworkCore;

namespace UdemyApi.Data
{
    public class UniversityDbContext:DbContext
    {
        public UniversityDbContext(DbContextOptions options) : base(options)    
        {
                
        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Department>().HasData( new Department { 
            Id = 1,
            Name="Computer Application",
            },
            new Department { 
            Id = 2,
            Name ="Information Technology"
            }
            );
            modelBuilder.Entity<Course>().HasData(
                new Course
                {
                    DepartmentId = 1,
                    Id=1,
                    Name="MCA"
                },
                 new Course
                 {
                     DepartmentId = 1,
                     Id = 2,
                     Name = "DA"
                 },
                  new Course
                  {
                      DepartmentId = 1,
                      Id = 3,
                      Name = "CS"
                  }
                ) ;
        }
    }
}
