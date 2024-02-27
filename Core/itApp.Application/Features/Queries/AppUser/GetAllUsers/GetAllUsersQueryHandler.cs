using itApp.Application.Abstractions.Services;
using MediatR;


namespace itApp.Application.Features.Queries.AppUser.GetAllUsers
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQueryRequest, GetAllUserQueryResponse>
    {
        readonly IUserService _userService;

        public GetAllUserQueryHandler()
        {
        }

        public GetAllUserQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<GetAllUserQueryResponse> Handle(GetAllUserQueryRequest request, CancellationToken cancellationToken)
        {
            // Eğer page veya size null ise, varsayılan değerleri kullan
            int page = request.Page ?? 1;
            int size = request.Size ?? 5;

            // UserService kullanarak kullanıcı listesini al
            var users = await _userService.GetAllUsersAsync(page, size);
            

            // Toplam kullanıcı sayısını almak için bir yöntem kullanmanız gerekebilir.
            // Örnek olarak, burada basitçe users.Count kullanıyorum, 
            // ama gerçekte bu, veritabanındaki toplam kullanıcı sayısını temsil etmelidir.
            int totalCount = users.Count; // Bu, daha karmaşık bir sorgu gerektirir.

            // GetAllUsersQueryResponse modelini doldurun
            var response = new GetAllUserQueryResponse
            {
                Users = users,
                Page = page,
                Size = size,
                TotalCount = totalCount
            };

            return response;
        }
    }
}
