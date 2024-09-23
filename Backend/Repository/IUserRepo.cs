using Backend.Models;

namespace Backend.Repositories
{
    public interface IUserRepo
    {
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(string id);
        Task<User> CreateUserAsync(User executive);
        Task UpdateUserAsync(string id, User executive);
        Task DeleteUserAsync(string id);
        Task<User> FindByEmailAsync(string email);

    }
}