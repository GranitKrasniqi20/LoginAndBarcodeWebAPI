using LoginAndBarcodeWebAPI.DTO;
using LoginAndBarcodeWebAPI.Models;

namespace LoginAndBarcodeWebAPI.Services.Contracts
{
    public interface IUserService
    {
        public Response RegisterUser(RegisterResponse model);

        public Response LoginUser(string username, string password);
    }
}
