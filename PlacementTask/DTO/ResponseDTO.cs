namespace PlacementTask.DTO
{
    public class ResponseDTO
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public object? Data { get; set; }
    }

    public static class Response
    {
        public static ResponseDTO SuccessResponse<T>(T data)
        {
            return new()
            {
                Data = data,
                Message = "Successful Operation",
                Status = true
            };
        }

        public static ResponseDTO ErrorResponse(string? message = null)
        {
            return new()
            {
                Data = null,
                Message = message ?? "Something went wrong",
                Status = false
            };
        }
    }
}
