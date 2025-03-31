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

	//getEntries
	Task<string> GetEntriesJsonAsync(string dictCode);
	Task<ApiResponse<List<EntryResponseModel>?>> GetEntriesAsync(string dictCode);

	//getEntry
	Task<string> GetEntryJsonAsync(string dictCode, string entryId, string format = "xml");
	Task<ApiResponse<EntryResponseModel?>> GetEntryAsync(string dictCode, string entryId);

}
