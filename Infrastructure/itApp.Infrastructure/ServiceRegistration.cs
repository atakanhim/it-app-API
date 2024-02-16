using itApp.Application.Abstractions.Token;
using itApp.Infrastructure.Services.Token;
using Microsoft.Extensions.DependencyInjection;


namespace itApp.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {

            services.AddScoped<ITokenHandler, TokenHandler>();
        }
    }
}
