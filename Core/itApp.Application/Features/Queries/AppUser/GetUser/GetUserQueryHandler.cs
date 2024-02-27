using itApp.Application.Abstractions.Services;
using itApp.Application.DTOs.User;
using MediatR;


namespace itApp.Application.Features.Queries.AppUser.GetUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQueryRequest, GetUserQueryResponse>
    {
        readonly IUserService _userService;

        public GetUserQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<GetUserQueryResponse> Handle(GetUserQueryRequest request, CancellationToken cancellationToken)
        {
            ListUser listuser = await _userService.GetUser(request.userid);
            return new()
            {
                User = listuser
            };
                
        }
    }
}
