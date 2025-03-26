using CambridgeDictionaryApi.Models;

namespace CambridgeDictionaryApi.Interfaces;

public interface ICambridgeApiClient
{
	//getDictionaries 
	Task<string> GetDictionariesJsonAsync();
	Task<ApiResponse<List<DictionaryResponseModel>?>> GetDictionariesAsync();

	//getDictionary
	Task<string> GetDictionaryJsonAsync(string dictCode);
	Task<ApiResponse<DictionaryResponseModel?>> GetDictionaryAsync(string dictCode);

	//Task<string> GetEntryJsonAsync(string dictCode, string entryId, string format = "html");
	//Task<string> GetNearbyEntriesJsonAsync(string dictCode, string entryId, int count = 5);

	
}
