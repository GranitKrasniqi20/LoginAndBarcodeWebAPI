using LoginAndBarcodeWebAPI.DTO;

namespace LoginAndBarcodeWebAPI.Utilities
{
    public class Result
    {
        public static Response Success() => new() { Status = ResponseStatus.Success };
        public static Response Success(dynamic data, string message = null) => new() { Status = ResponseStatus.Success, Data = data, Message = message };
        public static Response Fail(string message) => new() { Status = ResponseStatus.Fail, Message = message };
    }
}
