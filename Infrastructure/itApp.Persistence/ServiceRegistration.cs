﻿using itApp.Application.Abstractions.Services.Authentications;
using itApp.Application.Abstractions.Services;
using itApp.Domain.Entities.Identity;
using itApp.Persistence.Context;
using itApp.Persistence.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using itApp.Application.Mappings;
using itApp.Application.Repositories;
using itApp.Persistence.Repositories;

namespace itApp.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            // context
            //microsoft.extension.configrutaion added json dosyayı okucaz

            services.AddDbContext<itDbContext>(options => options.UseSqlServer(Configuration.ConnectionString));
            services.AddAutoMapper(typeof(ItAppProfile));

            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.User.RequireUniqueEmail = true;

            }).AddEntityFrameworkStores<itDbContext>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IExternalAuthentication, AuthService>();
            services.AddScoped<IInternalAuthentication, AuthService>();

            services.AddScoped<IDepartmentReadRepository, DepartmentReadRepository>();
            services.AddScoped<IDepartmentWriteRepository, DepartmentWriteRepository>();

            services.AddScoped<IEmployeReadRepository, EmployeReadRepository>();
            services.AddScoped<IEmployeWriteRepository, EmployeWriteRepository>();

            services.AddScoped<ILeaveRequestReadRepository, LeaveRequestReadRepository>();
            services.AddScoped<ILeaveRequestWriteRepository, LeaveRequestWriteRepository>();

            services.AddScoped<ILeaveTypeReadRepository, LeaveTypeReadRepository>();
            services.AddScoped<ILeaveTypeWriteRepository, LeaveTypeWriteRepository>();


            services.AddScoped<ICheckMarkReadRepository, CheckMarkReadRepository>();
            services.AddScoped<ICheckMarkWriteRepository, CheckMarkWriteRepository>();



        }

    }
}
