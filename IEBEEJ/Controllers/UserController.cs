using AutoMapper;
using IEBEEJ.Business.Models;
using IEBEEJ.Business.Services;
using IEBEEJ.DTOs.UserDTOs;
using Microsoft.AspNetCore.Mvc;

namespace IEBEEJ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IMapper _mapper;
        private IUserService _userService;

        public UserController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpPost]
        [Route("CreateUser")]
        public async Task<ActionResult> Post(AddUserDTO addUserDTO)
        {
            User user = _mapper.Map<User>(addUserDTO);
            await _userService.CreateAUserAsync(user);
            return Created();
        }

        [HttpPut]
        [Route("UpdateUser")]
        public async Task<ActionResult> UpdateUserAsync(User updatedUser)
        {
            if (ModelState.IsValid)
            {
                User user = _mapper.Map<User>(updatedUser);
                await _userService.UpdateUserAsync(user);
                return Created();
            }
           
                return BadRequest();
        }

        [HttpPut]
        [Route("UpdateUserRole")]
        public async Task<ActionResult> ChangeUserRole(User targetUser, int role)
        {
            if (ModelState.IsValid)
            {
                User user = _mapper.Map<User>(targetUser);
                await _userService.ChangeUserRoleAsync(user, role);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("UpdateUserActiveState")]
        public async Task<ActionResult> ChangeUserActiveState(User targetUser)
        {
            if (ModelState.IsValid)
            {
                User user = _mapper.Map<User>(targetUser);
                await _userService.ChangeAccountActiveStatus(user);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _userService.DeleteUserAsync(id);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> Get(int id)
        {
            User user = await _userService.GetUserByIdAsync(id);
            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            IEnumerable<User> users = await _userService.GetAllUsersAsync();
            IEnumerable<UserDTO> userDTOs = _mapper.Map<IEnumerable<UserDTO>>(users);
            return Ok(userDTOs);
        }

        [HttpGet]
        [Route("GetUserByName")]
        public async Task<ActionResult<UserDTO>> Get(string name)
        {
            User user = await _userService.GetUserByNameAsync(name);
            return Ok(user);
        }

        [HttpPost]
        [Route("UpdateUserInfo")]
        public async Task<ActionResult> UpdateUserInfoAsync(User updatedUser)
        {
            if (ModelState.IsValid)
            {
                User user = _mapper.Map<User>(updatedUser);
                await _userService.UpdateUserAsync(user);
                return Ok(user);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("UserLogin")]
        public async Task<ActionResult> UserLogin(string username, string password)
        {
            User userLoggingIn = await _userService.GetUserByNameAsync(username);
            if (userLoggingIn.Password == password)
            {
                return Ok(userLoggingIn);
            }
            return BadRequest();
        }
    }
}
