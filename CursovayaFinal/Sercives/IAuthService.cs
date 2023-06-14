using CursovayaFinal.Models;

namespace CursovayaFinal.Sercives
{
    public interface IAuthService
    {
        Task RegisterAsync(RegistrationModel registrationModel);
        Task AddEventAsync(DUevent eventDu);
        Task LoginAsync(string login, string password);
        Task DeleteEventAsync(string eventname);
        Task LogoutAsync();
    }
}
