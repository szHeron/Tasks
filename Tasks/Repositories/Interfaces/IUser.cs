using Tasks.Models;

namespace Tasks.Repositories.Interfaces
{
    public interface IUser
    {
        Task<List<UserModel>> SearchAllUsers();
        Task<UserModel> SearchUserById(Guid Id);
        Task<UserModel> AddNewUser(UserModel user);
        Task<UserModel> UpdateUser(UserModel user, Guid Id);
        Task<bool> DeleteUser(Guid Id);
    }
}
