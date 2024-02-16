using itApp.Application.Abstractions.Services.Authentications;
using itApp.Application.DTOs;
using MediatR;


namespace itApp.Application.Features.Commands.AppUser.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        readonly IInternalAuthentication _authService;
        public LoginUserCommandHandler(IInternalAuthentication authService)
        {
            _authService = authService;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            Token token = await _authService.LoginAsync(request.UsernameOrEmail, request.Password, 86400, 86400);
            return new LoginUserSuccessCommandResponse()
            {
                Token = token
            };
        }
    }
}
