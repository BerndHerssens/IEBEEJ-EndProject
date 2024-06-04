using IEBEEJ.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEBEEJ.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private IEBEEJDBContext _dbContext;
        public UserRepository(IEBEEJDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task ChangeUserRoleAsync(UserEntity userEntity, int role)
        {
            UserEntity tempUser = await _dbContext.Users
                .SingleOrDefaultAsync(x => x.Id == userEntity.Id);
            tempUser.Role = role;
            await _dbContext.SaveChangesAsync();
        }

        public async Task CreateUserAsync(UserEntity user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteUserByIDAsync(int id)
        {
            UserEntity user = new UserEntity() { Id = id };
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();

        }

        public async Task<IEnumerable<UserEntity>> GetAllUsersAsync(int skip, int take)
        {
            return await _dbContext.Users
                .Include(x => x.Bids)
                .Include(x =>x.ItemsForSale)
                .Skip(skip)
                .Take(take)
                .OrderBy(x => x.Id)
                .ToListAsync();
        }

        public async Task<UserEntity> GetOnlyUserAsync(int buyerID)
        {
            return await _dbContext.Users.FindAsync(buyerID);
        }

        public async Task<UserEntity> GetUserByIdAsync(int id)
        {
            return await _dbContext.Users
                .SingleOrDefaultAsync(x=>x.Id == id);
        }

        public async Task<UserEntity> GetUserByLoginAsync(string name, string password)
        {
            return await _dbContext.Users
                .SingleOrDefaultAsync(x => (x.Name == name) && (x.Password == password));
        }

        public async Task UpdateUserAsync(UserEntity user)
        {
            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}
