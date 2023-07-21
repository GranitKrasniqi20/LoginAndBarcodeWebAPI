using LoginAndBarcodeWebAPI.DTO;
using LoginAndBarcodeWebAPI.Models;
using LoginAndBarcodeWebAPI.Services.Contracts;
using LoginAndBarcodeWebAPI.Utilities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LoginAndBarcodeWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IUserService _userService;

        public LoginController(IConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;
            _userService = userService;
        }

        [Route("register")]
        [HttpPost]
        public IActionResult Register([FromBody]RegisterResponse user)
        { 
            var response = _userService.RegisterUser(user);
            return Ok(response);
        }

        [Route("login")]
        [HttpPost]
        public IActionResult Login([Required] string username, [Required] string password)
        {
            var response = _userService.LoginUser(username, password);

            return Ok(response);
        }
    }
}
