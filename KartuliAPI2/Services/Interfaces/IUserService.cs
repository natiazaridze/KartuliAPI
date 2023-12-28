using KartuliAPI2.Models.Identity;

namespace KartuliAPI2.Services.Interfaces
{
    public interface IUserService
    {
        Task<string> Signup(SignupModel model);
        Task<string> Login(LoginModel model);
    }
}
