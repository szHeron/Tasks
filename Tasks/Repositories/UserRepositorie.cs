using Microsoft.EntityFrameworkCore;
using Tasks.Data;
using Tasks.Models;
using Tasks.Repositories.Interfaces;

namespace Tasks.Repositories
{
    public class UserRepositorie : IUser
    {
        private readonly TasksDbContext _dbContext;
        public UserRepositorie(TasksDbContext tasksDbContext)
        {
            _dbContext = tasksDbContext;
        }
        public async Task<List<UserModel>> SearchAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<UserModel> SearchUserById(Guid Id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == Id);
        }
        public async Task<UserModel> AddNewUser(UserModel user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<UserModel> UpdateUser(UserModel user, Guid Id)
        {
            UserModel userById = await SearchUserById(Id);
            if(userById == null)
            {
                throw new Exception($"User ID: {Id} not found.");
            }
            userById.Name = user.Name;
            userById.Email = user.Email;
            _dbContext.Users.Update(userById);
            await _dbContext.SaveChangesAsync();

            return userById;
        }

        public async Task<bool> DeleteUser(Guid Id)
        {
            UserModel userById = await SearchUserById(Id);
            if (userById == null)
            {
                throw new Exception($"User ID: {Id} not found.");
            }

            _dbContext.Users.Remove(userById);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
