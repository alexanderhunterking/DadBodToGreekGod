using DadBodToGreekGod.Models.User;
using DadBodToGreekGod.Data.Entities;
using DadBodToGreekGod.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DadBodToGreekGod.Services.User
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<UserEntity> _userManager;
        private readonly SignInManager<UserEntity> _signInManager;
        private int _id;

        public UserService(ApplicationDbContext context,
                            UserManager<UserEntity> userManager,
                            SignInManager<UserEntity> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IEnumerable<UserDetail>> GetUserByIdAsync(int id)
        {
            List<UserDetail> users = await _context.Users
                .Where(u => u.Id == _id)
                .Select(u => new UserDetail{
                    Id = _id,
                HasMadeCalendar = u.HasMadeCalendar
                })
                .ToListAsync();

            return users;
        }

        public async Task<bool> RegisterUserAsync(UserRegister model)
        {   
            if(await CheckEmailAvailability(model.Email) == false)
            {
                System.Console.WriteLine("Please Try a Different Email, Email Entered Linked To Existing Account.");
                return false;
            }

            if(await CheckUserNameAvailability(model.UserName) == false)
            {
                System.Console.WriteLine("UserName already taken please try again");
                return false; 
            }

            UserEntity entity = new UserEntity()
            {
                HasMadeCalendar = false,
                Email = model.Email,
                UserName = model.UserName,
                DateCreated = DateTime.Now
            };

            IdentityResult registerResult = await _userManager.CreateAsync(entity, model.Password);

            return registerResult.Succeeded;
        }

        public async Task<bool> UpdateUserAsync(UserUpdate request, int id)
        {
            UserEntity? entity = await _context.Users
                .Where(u => u.Id == id)
                .FirstOrDefaultAsync();

            if (entity == null)
            {
                return false;
            }

            entity.HasMadeCalendar = request.HasMadeCalendar;

            int numberOfChanges = await _context.SaveChangesAsync();

            return numberOfChanges == 1;
        }

        private async Task<bool> CheckUserNameAvailability(string userName)
        {
            UserEntity? existingUser = await _userManager.FindByNameAsync(userName);
            return existingUser is null;
        }

        private async Task<bool> CheckEmailAvailability(string email)
        {
            UserEntity? existingUser = await _userManager.FindByEmailAsync(email);
            return existingUser is null; 
        }

        // private async Task<bool> IsEmailUniqueAsync(string email)
        // {
        //     // Check if the provided email is unique in the database.
        //     var existingUser = await _userManager.FindByEmailAsync(email);
        //     return existingUser == null;
        // }

        // private async Task<bool> IsUsernameUniqueAsync(string username)
        // {
        //     // Check if the provided username is unique in the database.
        //     var existingUser = await _userManager.FindByNameAsync(username);
        //     return existingUser == null;
        // }
    }
}