using AutoMapper;
using IEBEEJ.Data.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEBEEJ.Business.Services
{
    public class UserService
    {
        private IUserRepository _userRepository;
        private IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task CreateAUser(string name, EmailAddressAttribute email, string password, string adress, string phoneNumber, DateTime birthDay, Enum role)
        { 

        }
    }
}
