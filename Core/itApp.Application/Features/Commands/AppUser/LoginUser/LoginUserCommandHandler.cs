using itApp.Application.Abstractions.Services;
using itApp.Application.Abstractions.Services.Authentications;
using itApp.Application.DTOs;
using itApp.Application.DTOs.User;
using MediatR;


namespace itApp.Application.Features.Commands.AppUser.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        readonly IInternalAuthentication _authService;
        readonly IUserService _userService;

        public LoginUserCommandHandler(IInternalAuthentication authService,IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            LoginResponseDTO loginResponseDTO = await _authService.LoginAsync(request.UsernameOrEmail, request.Password, 86400, 86400);
            ListUser listuser = await _userService.GetUser(loginResponseDTO.username);
            return new LoginUserSuccessCommandResponse()
            {
                Token = loginResponseDTO.token,
                User = listuser
            };
        }
    }
}
