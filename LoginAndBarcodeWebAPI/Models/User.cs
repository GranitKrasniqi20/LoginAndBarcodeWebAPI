using System.ComponentModel.DataAnnotations;

namespace LoginAndBarcodeWebAPI.Models
{
    public class User
    {
        public int Id { get; set; }

        public int? RoleId { get; set; }

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
