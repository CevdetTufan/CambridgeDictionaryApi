using CambridgeDictionaryApi.Interfaces;
using CambridgeDictionaryApi.Models.ApiBase;
using System.Net;
using System.Text.Json;

namespace CambridgeDictionaryApi.Handlers;
public class CambridgeResponseHandler : ICambridgeResponseHandler
{
	private readonly JsonSerializerOptions _options = new()
	{
		PropertyNameCaseInsensitive = true
	};

	ApiResponse<TSuccess> ICambridgeResponseHandler.HandleResponse<TSuccess, TError>(HttpStatusCode statusCode, string json)
	{
		if (statusCode == HttpStatusCode.OK)
		{
			var data = JsonSerializer.Deserialize<TSuccess>(json, _options);
			return new ApiResponse<TSuccess> { IsSuccess = true, Data = data };
		}

		TError? error;

		try
		{
			error = JsonSerializer.Deserialize<TError>(json, _options);
		}
		catch
		{
			error = new TError
			{
				ErrorMessage = "Unknown error occurred",
				ErrorCode = statusCode.ToString()
			};
		}

		return new ApiResponse<TSuccess>
		{
			IsSuccess = false,
			Error = error
		};
	}
}

