using IEBEEJ.Business.Models;
using System.ComponentModel.DataAnnotations;

namespace IEBEEJ.Business.Services
{
    public interface IUserService
    {
        Task CreateAUserAsync(User user);

        Task<User> GetUserByIdAsync(int id);

        Task UpdateUserAsync(int id, User user);

        Task DeleteUserAsync(int id);

        Task<User> GetUserByNameAsync(string name);

        Task ChangeAccountActiveStatus(User user);

        Task<User> GetUserByLogin(string name, string password);

        Task<IEnumerable<User>> GetAllUsersAsync();

        Task ChangeUserRoleAsync(int id, User user, int role);

    }
}