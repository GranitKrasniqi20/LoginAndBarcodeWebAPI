using System.ComponentModel.DataAnnotations;

namespace LoginAndBarcodeWebAPI.DTO
{
    public class RegisterResponse
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*\d)(?=.*[!@#$%^&*])(?=.*[a-z])(?=.*[A-Z]).{8,}$", ErrorMessage = "Invalid Password")]
        public string Password { get; set; }

        [Required]
        public int LocationId { get; set; }

        [Required]
        public int ProjectId { get; set; }
    }
}
