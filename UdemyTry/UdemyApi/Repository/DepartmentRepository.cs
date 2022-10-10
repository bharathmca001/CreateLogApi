using Microsoft.EntityFrameworkCore;
using UdemyApi.Contract;
using UdemyApi.Data;

namespace UdemyApi.Repository
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        private readonly UniversityDbContext _context;

        public DepartmentRepository(UniversityDbContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<Department> GetDetails(int id)
        {
           return await _context.Departments.Include(q => q.Courses).FirstOrDefaultAsync(q => q.Id == id);
        }
    }
}
