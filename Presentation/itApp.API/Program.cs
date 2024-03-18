using itApp.Persistence;
using itApp.Infrastructure;
using itApp.Application;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using itApp.Infrastructure.Filters;
using FluentValidation.AspNetCore;
using itApp.Application.Validators.Products;
using itApp.API.Extensions;
using System.Security.Claims;



// logger ve serilog eklenecek


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddPersistenceServices();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = true,
            ValidateIssuer = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidAudience = builder.Configuration["Token:Audience"],
            ValidIssuer = builder.Configuration["Token:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),
            NameClaimType = ClaimTypes.Name //JWT �zerinde Name claimne kar��l�k gelen de�eri User.Identity.Name propertysinden elde edebiliriz.

        };
    });




builder.Services.AddControllers(options => options.Filters.Add<ValidationFilter>())
    .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<CreateProductValidator>())
    .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


app.ConfigureExceptionHandler<Program>(app.Services.GetRequiredService<ILogger<Program>>());


app.UseRouting();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseCors(options =>
{
    options.AllowAnyOrigin(); // Tüm kaynaklara erişime izin verir
    options.AllowAnyMethod(); // Tüm HTTP metodlarına izin verir
    options.AllowAnyHeader(); // Tüm başlıklara izin verir
});
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();// yetkilendirme

app.MapControllers();

app.Run();
