using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using CursovayaFinal.Models;
using Microsoft.EntityFrameworkCore;
using Blazored.LocalStorage;

namespace CursovayaFinal.Sercives
{
    public class AuthService : IAuthService

    {
        private readonly ILocalStorageService _localStorageService;
        private AppDbContext _appDbContext;

        public AuthService(AppDbContext appDbContext, ILocalStorageService localStorageService)
        {
            _appDbContext = appDbContext;
            _localStorageService = localStorageService;
        }
        public async Task DeleteEventAsync(string eventname)
        {
             _appDbContext.Remove(_appDbContext.Events.SingleOrDefaultAsync(n => n.Name == "_eventNameDelete"));
            await _appDbContext.SaveChangesAsync();
        }
        public async Task AddEventAsync(DUevent eventDu)
		{
			await _appDbContext.Events.AddAsync(eventDu);
            await _appDbContext.SaveChangesAsync();
        }

		public async Task LoginAsync(string login, string password)
        {
            await _localStorageService.RemoveItemAsync("user");
            var user = await _appDbContext.Users.FirstOrDefaultAsync(u => u.Login == login);
            if (user is null)
            {
                throw new Exception(
                    $"User with username {login} does not exists");
            }
            var userInfo = new UserInfo
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                RoleId = user.RoleId,
            };
            await _localStorageService.SetItemAsync("user", userInfo);
            await _localStorageService.SetItemAsync("loggedIn", true);
        }

        public async Task LogoutAsync()
        {
            await _localStorageService.RemoveItemAsync("user");
            await _localStorageService.SetItemAsync("loggedIn", false);
        }

        public async Task RegisterAsync(RegistrationModel registrationModel)
        {
            User user = new User()
            {
                Name = registrationModel.Name,
                Surname = registrationModel.Surname,
                Password = registrationModel.Password,
                Login = registrationModel.Login,
                RoleId = 1,
            };
            await _appDbContext.Users.AddAsync(user);
            await _appDbContext.SaveChangesAsync();
            await LoginAsync(registrationModel.Login, registrationModel.Password);
        }
    }
}