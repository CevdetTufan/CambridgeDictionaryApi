using CambridgeDictionaryApi.Interfaces;
using CambridgeDictionaryApi.Models;

namespace CambridgeDictionaryApi.Services;

public class CambridgeApiClient : ICambridgeApiClient
{
	private readonly ICambridgeRequestHandler _requestHandler;
	private readonly ICambridgeResponseHandler _responseHandler;

	public CambridgeApiClient(ICambridgeRequestHandler requestHandler, ICambridgeResponseHandler responseHandler)
	{
		_requestHandler = requestHandler;
		_responseHandler = responseHandler;
	}

	/// <summary>
	/// getDictionaries with json response
	/// </summary>
	/// <returns></returns>
	public async Task<string> GetDictionariesJsonAsync()
	{
		return await _requestHandler.SendGetRequestAsync("dictionaries");
	}


	/// <summary>
	/// getDictionaries with ApiResponse response
	/// </summary>
	/// <returns></returns>
	public async Task<ApiResponse<List<DictionaryResponseModel>?>> GetDictionariesAsync()
	{
		var (statusCode, json) = await _requestHandler.SendGetRequestWithStatusAsync("dictionaries");
		return _responseHandler.HandleResponse<List<DictionaryResponseModel>?, ApiErrorResponse>(statusCode, json);
	}

	/// <summary>
	/// getDictionary with json response
	/// </summary>
	/// <param name="dictCode"></param>
	/// <returns></returns>
	public async Task<string> GetDictionaryJsonAsync(string dictCode)
	{
		return await _requestHandler.SendGetRequestAsync($"dictionaries/{dictCode}");
	}

	/// <summary>
	/// getDictionary with ApiResponse response
	/// </summary>
	/// <param name="dictCode"></param>
	/// <returns></returns>
	public async Task<ApiResponse<DictionaryResponseModel?>> GetDictionaryAsync(string dictCode)
	{
		var (statusCode, json) = await _requestHandler.SendGetRequestWithStatusAsync($"dictionaries/{dictCode}");
		return _responseHandler.HandleResponse<DictionaryResponseModel?, ApiErrorResponse>(statusCode, json);
	}

	/// <summary>
	/// getEntries with json response
	/// </summary>
	/// <param name="dictCode"></param>
	/// <returns></returns>
	public async Task<string> GetEntriesJsonAsync(string dictCode)
	{
		return await _requestHandler.SendGetRequestAsync($"dictionaries/{dictCode}/entries");
	}

	/// <summary>
	/// getEntries with ApiResponse response
	/// </summary>
	/// <param name="dictCode"></param>
	/// <returns></returns>
	public async Task<ApiResponse<List<EntryResponseModel>?>> GetEntriesAsync(string dictCode)
	{
		var (statusCode, json) = await _requestHandler.SendGetRequestWithStatusAsync($"dictionaries/{dictCode}/entries");
		return _responseHandler.HandleResponse<List<EntryResponseModel>?, ApiErrorResponse>(statusCode, json);
	}

	//getEntry
	//getEntry with json response
	public async Task<string> GetEntryJsonAsync(string dictCode, string entryId, string format = "xml")
	{
		return await _requestHandler.SendGetRequestAsync($"dictionaries/{dictCode}/entries/{entryId}?format={format}");
	}

	//getEntry with ApiResponse response
	public async Task<ApiResponse<EntryResponseModel?>> GetEntryAsync(string dictCode, string entryId)
	{
		var (statusCode, json) = await _requestHandler.SendGetRequestWithStatusAsync($"dictionaries/{dictCode}/entries/{entryId}?format=xml");
		return _responseHandler.HandleResponse<EntryResponseModel?, ApiErrorResponse>(statusCode, json);
	}
}

