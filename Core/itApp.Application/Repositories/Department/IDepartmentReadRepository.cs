using itApp.Domain.Entities;


namespace itApp.Application.Repositories
{
    public interface IDepartmentReadRepository:IReadRepository<Department>
    {
        public  Task<bool> IsDepartmentNameExists(string departmentName);
    }
}
