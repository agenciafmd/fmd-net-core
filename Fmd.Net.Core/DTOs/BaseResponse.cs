namespace Fmd.Net.Core.DTOs;

public class BaseResponse<T>(bool success, T data, string message = "", List<string>? errors = null)
    where T : class
{
    public bool Success { get; set; } = success;
    public string Message { get; set; } = message;
    public List<string>? Errors { get; set; } = errors;
    public T Data { get; set; } = data;
}