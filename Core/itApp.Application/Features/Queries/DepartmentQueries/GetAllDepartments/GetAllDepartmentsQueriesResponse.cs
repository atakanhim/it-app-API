using itApp.Application.DTOs;


namespace itApp.Application.Features.Queries.DepartmentQueries.GetAllDepartments
{
    public class GetAllDepartmentsQueriesResponse
    {
        public IEnumerable<DepartmentDTO>? Departments { get; set; } // Kullanıcı listesi

    }
}
