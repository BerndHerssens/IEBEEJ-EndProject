
using AutoMapper;
using IEBEEJ.Business.Services;
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
    }
}
