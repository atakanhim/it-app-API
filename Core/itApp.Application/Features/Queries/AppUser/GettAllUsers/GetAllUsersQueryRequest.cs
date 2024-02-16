using MediatR;

namespace itApp.Application.Features.Queries.AppUser.GettAllUsers
{
    public class GetAllUsersQueryRequest : IRequest<GetAllUsersQueryResponse>
    {
        public int? Page { get; set; } = 1; 
        public int? Size { get; set; } = 5;
    }
}
