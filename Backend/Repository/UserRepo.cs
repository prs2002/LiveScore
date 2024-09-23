using Backend.Models;
using Backend.Repositories;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Backend.Repositories
{
    public class UserRepo : IUserRepo
    {

        private readonly IMongoCollection<User> _users;

        public UserRepo(IMongoDatabase database)
        {
            _users = database.GetCollection<User>("users");
        }
        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _users.Find(user => true).ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(string id)
        {
            return await _users.Find(user => user.Id == id).FirstOrDefaultAsync();
        }
        public async Task<User> CreateUserAsync(User user)
        {
            await _users.InsertOneAsync(user);
            return user;
        }

        public async Task UpdateUserAsync(string id, User user)
        {
            await _users.ReplaceOneAsync(e => e.Id == id, user);
        }

        public async Task DeleteUserAsync(string id)
        {
            await _users.DeleteOneAsync(executive => executive.Id == id);
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            return await _users.Find(c => c.Email == email).FirstOrDefaultAsync();
        }
    }
}
