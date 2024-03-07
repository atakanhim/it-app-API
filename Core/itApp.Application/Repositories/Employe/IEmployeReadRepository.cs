using itApp.Domain.Entities;


namespace itApp.Application.Repositories
{
    public interface IEmployeReadRepository:IReadRepository<Employe>
    {
        public Task<bool> IsEmployeExists(string telNo);
    }
}
