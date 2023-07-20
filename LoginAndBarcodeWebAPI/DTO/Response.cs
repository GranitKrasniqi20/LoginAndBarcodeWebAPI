namespace LoginAndBarcodeWebAPI.DTO
{
    public class Response
    {
        public static object Headers { get; internal set; }
        public ResponseStatus Status { get; set; }
        public string Message { get; set; }
        public dynamic Data { get; set; }
    }

    public enum ResponseStatus
    {
        Success,
        Fail,
        Redirect
    }
}
