using BookMyShowBusiness.Services;
using BookMyShowEntity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieAppCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody] User userInfo)
        {
            _userService.Register(userInfo);
            return Ok("Register successfully!!");
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] User user)
        {
            User userInfo = _userService.Login(user);
            if (userInfo != null)
                return Ok("Login success!!");
            else
                return NotFound();
        }


    }
}
