
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using itApp.Application.Mappings;

namespace itApp.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            
            services.AddMediatR(typeof(ServiceRegistration)); // bu sınıfın bulundugu assemlbdeki tüm , ihandler , irequest sınıflarını bul ve aracı ol

        }
    }
}