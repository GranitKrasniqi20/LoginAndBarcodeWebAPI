using LoginAndBarcodeWebAPI.DTO;
using LoginAndBarcodeWebAPI.Models;

namespace LoginAndBarcodeWebAPI.Services.Contracts
{
    public interface IUserService
    {
        public Response RegisterUser(User model);

        public Response LoginUser(string username, string password);
    }
}
