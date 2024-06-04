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
        [Route("UpdateUserFull")]
        public async Task<ActionResult> UpdateUserAsync(int id, User updatedUser)
        {
            if (ModelState.IsValid)
            {
                User user = _mapper.Map<User>(updatedUser);
                await _userService.UpdateUserAsync(id, user);
                return Created();
            }
                return BadRequest();
        }

        [HttpPut]
        [Route("UpdateUserInfo")]
        public async Task<ActionResult> UpdateUserInfoAsync(int id, UpdateUserDTO updatedUser) //moet een Id meegeven
        {
            if (ModelState.IsValid)
            {
                User user = _mapper.Map<User>(updatedUser);
                await _userService.UpdateUserAsync(id, user);
                return Ok(user);
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("UpdateUserRole")]
        public async Task<ActionResult> ChangeUserRole(int id, User targetUser, int role)
        {
            if (ModelState.IsValid)
            {
                User user = _mapper.Map<User>(targetUser);
                await _userService.ChangeUserRoleAsync(id,user, role);
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

        [HttpDelete]
        public async Task Delete(int id)
        {
            await _userService.DeleteUserAsync(id);
        }

        [HttpGet]
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
            if (userDTOs != null)
            {
                return Ok(userDTOs);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("GetUserByName")]
        public async Task<ActionResult<UserDTO>> Get(string name)
        {
            User user = await _userService.GetUserByNameAsync(name);
            UserDTO userDTO = _mapper.Map<UserDTO>(user);
            if (userDTO != null)
            {
                return Ok(userDTO);
            }
            else
            {
                return NotFound();
            }
           
        }

        

        [HttpGet]
        [Route("UserLogin")]
        public async Task<ActionResult> UserLogin(string username, string password)
        {
            User userLoggingIn = await _userService.GetUserByLogin(username, password);
            if (userLoggingIn == null)
            {
                return NotFound();
            }
            else
            {
                LoginDTO loginDTO = _mapper.Map<LoginDTO>(userLoggingIn);
                return Ok(loginDTO);
            }
        }
    }
}
