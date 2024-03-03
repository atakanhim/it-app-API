using MediatR;


namespace itApp.Application.Features.Queries.EmployeeQueries.GetEmployee
{
    public class GetEmployeeQueriesRequest : IRequest<GetEmployeeQueriesResponse>
    {
        public string EmployeeId { get; set; }
    }
}
