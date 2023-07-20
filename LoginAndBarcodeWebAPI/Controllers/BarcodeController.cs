using LoginAndBarcodeWebAPI.Models;
using LoginAndBarcodeWebAPI.Services.Contracts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LoginAndBarcodeWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarcodeController : ControllerBase
    {
        private readonly IBarcodeService _barcodeService;
        public BarcodeController(IBarcodeService barcodeService)
        {
            _barcodeService = barcodeService;
        }


        [Route("registerBarcode")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public IActionResult RegisterBarcode([FromBody] string barcodeText)
        {
            var response = _barcodeService.RegisterBarcode(barcodeText);
            return Ok(response);
        }

    }
}
