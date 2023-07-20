using LoginAndBarcodeWebAPI.DTO;
using LoginAndBarcodeWebAPI.Models;
using LoginAndBarcodeWebAPI.Services.Contracts;
using LoginAndBarcodeWebAPI.Utilities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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
        public IActionResult Register([FromBody]User user)
        { 
            var response = _userService.RegisterUser(user);
            return Ok(response);
        }

        [Route("login")]
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var response = _userService.LoginUser(username, password);
            //// Validate the user credentials against the database
            //var user = AuthenticateUser(username, password);

            //if (user == null)
            //{
            //    return BadRequest(new { message = "Invalid credentials" });
            //}

            //// Generate a token (You can use JWT or any other token-based authentication mechanism)
            //var token = GenerateJsonWebToken(user);

            // Return the authentication token along with user information
            //var message = new LoginResponse
            //{
            //    Token = token,
            //    UserId = user.Data.Id,
            //    LocationId = user.Data.LocationId,
            //    ProjectId = user.Data.ProjectId
            //};

            return Ok(response);
        }
    }
}
