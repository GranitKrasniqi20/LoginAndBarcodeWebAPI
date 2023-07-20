using LoginAndBarcodeWebAPI.DTO;
using LoginAndBarcodeWebAPI.Models;
using LoginAndBarcodeWebAPI.Services.Contracts;
using LoginAndBarcodeWebAPI.Utilities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LoginAndBarcodeWebAPI.Services
{
    public class UserService : IUserService
    {
        public IConfiguration _configuration;
        private readonly DatabaseContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserService(IConfiguration configuration, DatabaseContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public Response RegisterUser(User model)
        {
            User user = new User();
            user.Username = model.Username;
            user.Password = EncryptionUtility.Encrypt(model.Password);
            user.LocationId = model.LocationId;
            user.ProjectId = model.ProjectId;
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            user.Password = user.Password = "";//Dont return passwords hash.
            return user.Id > 0 ? Result.Success(user, "Success") : Result.Fail("Problem during user creation");
        }

        public Response LoginUser(string username, string password)
        {
            var user = AuthenticateUser(username, password);
            if (user.Id > 0)
            {
                var token = GenerateJsonWebToken(user);
                if (token == null || token == "")
                {
                    Result.Fail("Token not created!");
                }

                user.Password = "";//Dont return passwords hash.

                var result = new LoginResponse
                {
                    Token = token,
                    UserId = user.Id,
                    LocationId = user.LocationId,
                    ProjectId = user.ProjectId
                };
                return Result.Success(result, "Success");
            }
            return Result.Fail("Wrong credentials!");
        }

        private string GenerateJsonWebToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Name, user.Username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var datetimeNow = DateTime.Now;
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Issuer"],
                claims: claims,
                expires: datetimeNow.AddMinutes(30),
                signingCredentials: credentials

                );

            var encodetoken = new JwtSecurityTokenHandler().WriteToken(token);
            return encodetoken;
        }

        private User AuthenticateUser(string username, string password)
        {
            var user = _dbContext.Users.Where(x => x.Username == username).FirstOrDefault();

            if (user != null)
            {
                if (EncryptionUtility.Verify(password, user.Password))
                {
                    return user;
                }
            }
            return new User();
        }
    }
}
