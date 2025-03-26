using CambridgeDictionaryApi.Interfaces;
using CambridgeDictionaryApi.Models;
using System.Net;
using System.Text.Json;

namespace CambridgeDictionaryApi.Services;

public class CambridgeApiClient : ICambridgeApiClient
{
	private readonly ICambridgeRequestHandler _requestHandler;
	private readonly JsonSerializerOptions _jsonSerializerOptions;

	public CambridgeApiClient(ICambridgeRequestHandler requestHandler)
	{
		_requestHandler = requestHandler;
		_jsonSerializerOptions = new JsonSerializerOptions
		{
			PropertyNameCaseInsensitive = true
		};
	}

	/// <summary>
	/// getDictionaries with json response
	/// </summary>
	/// <returns></returns>
	public Task<string> GetDictionariesJsonAsync()
	{
		return _requestHandler.SendGetRequestAsync("dictionaries");
	}


	/// <summary>
	/// getDictionaries with ApiResponse response
	/// </summary>
	/// <returns></returns>
	public Task<ApiResponse<List<DictionaryResponseModel>?>> GetDictionariesAsync()
	{
		return GetApiResponseAsync<List<DictionaryResponseModel>?, ApiErrorResponse>("dictionaries");
	}

	public Task<string> GetDictionaryJsonAsync(string dictCode)
	{
		return _requestHandler.SendGetRequestAsync($"dictionaries/{dictCode}");
	}

	public Task<ApiResponse<DictionaryResponseModel?>> GetDictionaryAsync(string dictCode)
	{
		return GetApiResponseAsync<DictionaryResponseModel?, ApiErrorResponse>($"dictionaries/{dictCode}");
	}


	#region Helper
	private async Task<ApiResponse<TSuccess>> GetApiResponseAsync<TSuccess, TError>(string endpoint) where TError : ApiErrorResponse, new()
	{
		var (statusCode, json) = await _requestHandler.SendGetRequestWithStatusAsync(endpoint);

		if (statusCode == HttpStatusCode.OK)
		{
			var data = JsonSerializer.Deserialize<TSuccess>(json, _jsonSerializerOptions);
			return new ApiResponse<TSuccess> { IsSuccess = true, Data = data };
		}

		TError? error;

		try
		{
			error = JsonSerializer.Deserialize<TError>(json, _jsonSerializerOptions);
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
	#endregion
}

