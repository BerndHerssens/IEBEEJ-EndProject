﻿using IEBEEJ.Business.Models;
using System.ComponentModel.DataAnnotations;

namespace IEBEEJ.Business.Services
{
    public interface IUserService
    {
        Task CreateAUserAsync(User user);

        Task<User> GetUserByIdAsync(int id);

        Task UpdateUserAsync(User user);

        Task DeleteUserAsync(int id);

        Task<User> GetUserByNameAsync(string name);

        Task ChangeAccountActiveStatus(User user);

        Task ChangeUserRole(User user, Enum role);

        Task<User> GetUserByLogin(string name, string password);

        Task<IEnumerable<User>> GetAllUsersAsync();

        // todo : Eens kijken naar de lists
    }
}