using LoginAndBarcodeWebAPI.DTO;
using LoginAndBarcodeWebAPI.Models;

namespace LoginAndBarcodeWebAPI.Services.Contracts
{
    public interface IBarcodeService
    {
        public Response RegisterBarcode(string barcodeText);
    }
}
