using DadBodToGreekGod.Models.User;

namespace DadBodToGreekGod.Services.User
{
    public interface IUserService
    {
        Task<bool> RegisterUserAsync(UserRegister model);
        Task<bool> UpdateUserAsync(UserUpdate request, int id);
       Task<IEnumerable<UserDetail>> GetUserByIdAsync(int id);


    }
}