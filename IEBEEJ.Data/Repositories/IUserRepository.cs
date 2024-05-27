using IEBEEJ.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEBEEJ.Data.Repositories
{
    public interface IUserRepository
    {
        Task CreateUserAsync(UserEntity user);
        Task DeleteUserByIDAsync(int id);
        Task<IEnumerable<UserEntity>> GetAllUsersAsync(int skip, int take);
        Task<UserEntity> GetUserByIdAsync(int id);
        Task UpdateUserAsync(UserEntity user);
        Task<UserEntity> GetUserByLoginAsync(string name, string password);
        Task ChangeUserRoleAsync(UserEntity userEntity, int role);
    }
}
