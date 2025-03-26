namespace CambridgeDictionaryApi.Models;
public class ApiResponse<T>
{
	public bool IsSuccess { get; set; }
	public T? Data { get; set; }
	public ApiErrorResponse? Error { get; set; }
}

public class ApiErrorResponse
{
	public string? ErrorCode { get; set; }
	public string? ErrorMessage { get; set; }
}
