namespace Gdpr.Application.DTOs;

public class ApiResponse<T>
{
    public bool Success { get; set; }
    public T Data { get; set; }
    public string Message { get; set; } = null!;

    public static ApiResponse<T> SuccessResponse(T data, string message = "")
    {
        return new ApiResponse<T>
        {
            Success = true,
            Data = data,
            Message = message
        };
    }

    public static ApiResponse<T> Failure(string message)
    {
        return new ApiResponse<T>
        {
            Success = false,
            Message = message
        };
    }
}