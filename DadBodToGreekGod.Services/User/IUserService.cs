using DadBodToGreekGod.Models.User;

namespace DadBodToGreekGod.Services.User
{
    public interface IUserService
    {
        Task<bool> RegisterUserAsync(UserRegister model);
        Task<UserDetail?> GetUserByIdAsync(int userId);
    }
}