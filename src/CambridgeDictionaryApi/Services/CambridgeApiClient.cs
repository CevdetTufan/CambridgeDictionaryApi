using CambridgeDictionaryApi.Interfaces;
using CambridgeDictionaryApi.Models;
using CambridgeDictionaryApi.Models.ApiBase;

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

	//getNearbyEntries with json response
	public async Task<string> GetNearbyEntriesJsonAsync(string dictCode, string entryId, int entryNumber = 5)
	{
		return await _requestHandler.SendGetRequestAsync($"dictionaries/{dictCode}/entries/{entryId}/nearbyentries/?entrynumber={entryNumber}");
	}

	//getNearbyEntries with ApiResponse response
	public async Task<ApiResponse<NearbyEntryResponseModel?>> GetNearbyEntriesAsync(string dictCode, string entryId, int entryNumber = 5)
	{
		var (statusCode, json) = await _requestHandler.SendGetRequestWithStatusAsync($"dictionaries/{dictCode}/entries/{entryId}/nearbyentries/?entrynumber={entryNumber}");
		return _responseHandler.HandleResponse<NearbyEntryResponseModel?, ApiErrorResponse>(statusCode, json);
	}


	/// <summary>
	/// getEntryPronunciations with json response
	/// </summary>
	/// <param name="dictCode"></param>
	/// <param name="entryId"></param>
	/// <param name="format">uk or us. Default Uk</param>
	/// <param name="lang">mp3 or ogg. Default mp3</param>
	/// <returns></returns>
	public async Task<string> GetEntryPronunciationsJsonAsync(string dictCode, string entryId, string format = "mp3", string lang = "uk")
	{
		return await _requestHandler.SendGetRequestAsync($"dictionaries/{dictCode}/entries/{entryId}/pronunciations?lang={lang}&format={format}");
	}

	//getEntryPronunciations with ApiResponse response
	public async Task<ApiResponse<List<EntryPronunciationResponseModel>?>> GetEntryPronunciationsAsync(string dictCode, string entryId, string format = "mp3", string lang = "uk")
	{
		var (statusCode, json) = await _requestHandler.SendGetRequestWithStatusAsync($"dictionaries/{dictCode}/entries/{entryId}/pronunciations?lang={lang}&format={format}");

		return _responseHandler.HandleResponse<List<EntryPronunciationResponseModel>?, ApiErrorResponse>(statusCode, json);
	}
}

