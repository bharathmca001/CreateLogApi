using UdemyApi.Data;

namespace UdemyApi.Contract
{
    public interface IDepartmentRepository : IGenericRepository<Department>
    {
        Task<Department> GetDetails(int id);

    }
}
