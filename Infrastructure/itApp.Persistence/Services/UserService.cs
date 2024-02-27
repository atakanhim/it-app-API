using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using itApp.Application.Abstractions.Services;
using itApp.Application.DTOs.User;
using itApp.Application.Exceptions;
using itApp.Domain.Entities.Identity;
using AutoMapper;
using itApp.Application.DTOs;
using itApp.Domain.Entities;
using System.Collections.Generic;

namespace itApp.Persistence.Services
{
    public class UserService : IUserService
    {
        readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;
        private IMapper _mapper;
        public UserService(UserManager<AppUser> userManager,IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public int TotalUsersCount => throw new NotImplementedException();

        public Task AssignRoleToUserAsnyc(string userId, string[] roles)
        {
            throw new NotImplementedException();
        }

        public async Task<CreateUserResponse> CreateAsync(CreateUser model)
        {
            IdentityResult result = await _userManager.CreateAsync(new()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = model.Username,
                Email = model.Email,
                RefreshToken = "",// create aşamasında bos olamaz hatası alıyoruz 
                RefreshTokenEndDate = DateTime.UtcNow,
            }, model.Password);
            
            CreateUserResponse response = new() { Succeeded = result.Succeeded };

            if (result.Succeeded)
            {
                response.Message = "Kullanıcı başarıyla oluşturulmuştur.";
            }
               
            else
                foreach (var error in result.Errors)
                    response.Message += $"{error.Code} - {error.Description}\n";

            return response;
        }

        public async Task<List<ListUser>> GetAllUsersAsync(int page, int size)
        {
            // Kullanıcıların sayfalı olarak alınması
            var users = await _userManager.Users
                                         .Skip((page - 1) * size)
                                         .Take(size)
                                         .ToListAsync();

          
            var userList = users.Select(user => new ListUser
            {
                Id = user.Id,
                Email = user.Email, 
                UserName = user.UserName,       
            }).ToList();

            return userList;
        }

        public Task<string[]> GetRolesToUserAsync(string userIdOrName)
        {
            throw new NotImplementedException();
        }

        public async Task<ListUser> GetUser(string userid)
        {
            var user = await _userManager.Users
                 .Include(u => u.Employees) // Kullanıcıların personellerini al
                 .Where(x=>x.Id == userid)
                 .FirstOrDefaultAsync();

            ICollection<Employe> employe = user?.Employees;

            ICollection<EmployeDTO> dtoemploye = _mapper.Map<ICollection<Employe>, ICollection<EmployeDTO>>(employe);

            return new () {
                Id = user.Id,
                UserName = user.UserName,
                Email =user.Email,
                Employees = dtoemploye
            };
        }

        public Task<bool> HasRolePermissionToEndpointAsync(string name, string code)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePasswordAsync(string userId, string resetToken, string newPassword)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateRefreshTokenAsync(string? refreshToken, AppUser user, DateTime? accessTokenDate, int addOnAccessTokenDate)
        {
            if (user != null)
            {
                user.RefreshToken = refreshToken;
                user.RefreshTokenEndDate = (DateTime)(accessTokenDate?.AddSeconds(addOnAccessTokenDate));
                await _userManager.UpdateAsync(user);
            }
            else
                throw new NotFoundUserException();
        }

    }
}
