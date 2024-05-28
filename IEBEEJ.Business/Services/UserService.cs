using AutoMapper;
using IEBEEJ.Business.Models;
using IEBEEJ.Data.Entities;
using IEBEEJ.Data.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEBEEJ.Business.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task CreateAUserAsync(User user)
        {
            UserEntity userEntity = _mapper.Map<UserEntity>(user);
            await _userRepository.CreateUserAsync(userEntity);
        }

        public async Task ChangeUserRoleAsync(User user, int role)
        {
            UserEntity userEntity = _mapper.Map<UserEntity>(user);
            await _userRepository.ChangeUserRoleAsync(userEntity, role);
        }

        public async Task ChangeAccountActiveStatus(User user)
        {
            user.IsActive = !user.IsActive;
            UserEntity userEntity = _mapper.Map<UserEntity>(user);
            await _userRepository.UpdateUserAsync(userEntity);
        }

        public async Task DeleteUserAsync(int id)
        {
            await _userRepository.DeleteUserByIDAsync(id);
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            UserEntity userEntity = await _userRepository.GetUserByIdAsync(id);

            if (userEntity != null)
            {
                User user = _mapper.Map<User>(userEntity);
                return user;
            }
            else
            {
                return null; //TODO: throw exception
            }
            
        }

        public async Task<User> GetUserByNameAsync(string name)
        {
            throw new NotImplementedException(); //todo : eens uitzoeken hoe het zit met substringzoekfuncties
        }

        public async Task UpdateUserAsync(User user)
        {
            UserEntity userEntity = await _userRepository.GetUserByIdAsync(user.Id);
            UserEntity updatedEntity = _mapper.Map<UserEntity>(user);

            userEntity.Adress = updatedEntity.Adress;
            userEntity.Email = updatedEntity.Email;
            userEntity.PhoneNumber = updatedEntity.PhoneNumber;
            userEntity.Name = updatedEntity.Name;
            userEntity.Birthday = updatedEntity.Birthday;
            userEntity.Password = updatedEntity.Password;
            userEntity.Bids = updatedEntity.Bids;
            userEntity.ItemsForSale = updatedEntity.ItemsForSale;
            userEntity.LikedUsers = updatedEntity.LikedUsers;

            await _userRepository.UpdateUserAsync(userEntity);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            IEnumerable<UserEntity> userEntities = await _userRepository.GetAllUsersAsync(0, 1000);
            IEnumerable<User> users = _mapper.Map<IEnumerable<User>>(userEntities);
            return users;
        }

        public async Task<User> GetUserByLogin(string name, string password)
        {
            IEnumerable<UserEntity> userEntities = await _userRepository.GetAllUsersAsync(0, 1000);
            UserEntity userEntity = userEntities.SingleOrDefault(x => (x.Name == name) && (x.Password == password));

            if (userEntity != null)
            {
                User user = _mapper.Map<User>(userEntity);
                return user;
            }
            else
            {
                return null; //TODO: throw exception
            }
        }
    }
}
