using System.ComponentModel.DataAnnotations;

namespace LoginAndBarcodeWebAPI.DTO
{
    public class BarcodeResponse
    {
        [Required]
        public string Text { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }
    }
}
