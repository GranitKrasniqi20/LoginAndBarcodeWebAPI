namespace LoginAndBarcodeWebAPI.DTO
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public int UserId { get; set; }
        public int LocationId { get; set; }
        public int ProjectId { get; set; }
    }
}
