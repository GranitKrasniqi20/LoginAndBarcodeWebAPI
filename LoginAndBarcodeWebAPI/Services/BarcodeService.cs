using LoginAndBarcodeWebAPI.DTO;
using LoginAndBarcodeWebAPI.Models;
using LoginAndBarcodeWebAPI.Services.Contracts;
using LoginAndBarcodeWebAPI.Utilities;

namespace LoginAndBarcodeWebAPI.Services
{
    public class BarcodeService : IBarcodeService
    {
        public IConfiguration _configuration;
        private readonly DatabaseContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public BarcodeService(IConfiguration configuration, DatabaseContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public Response RegisterBarcode(string barcodeText)
        {
            Barcode barcode = new();
            barcode.Text = barcodeText;
            barcode.Timestamp = DateTime.Now;   
            _dbContext.Add(barcode);
            _dbContext.SaveChanges();

            var result = new BarcodeResponse
            {
                Text = barcode.Text,
                Timestamp = DateTime.Now,
            };
            return barcode.Id > 0 ? Result.Success(result, "Success") : Result.Fail("Problem during barcode creation");

        }
    }
}
