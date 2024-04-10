
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using itApp.Application.Mappings;
using itApp.Application.Abstractions.Services;
using itApp.Application.Abstractions.Utilities;
using itApp.Application.Utilities;

namespace itApp.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            
            services.AddMediatR(typeof(ServiceRegistration)); // bu sınıfın bulundugu assemlbdeki tüm , ihandler , irequest sınıflarını bul ve aracı ol
            services.AddSingleton<ICustomGuidConverter, CustomGuidConverter>();

        }
    }
}