using CambridgeDictionaryApi.Models;
using CambridgeDictionaryApi.Models.ApiBase;

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

	//getNearbyEntries
	Task<string> GetNearbyEntriesJsonAsync(string dictCode, string entryId, int entryNumber = 5);
	Task<ApiResponse<NearbyEntryResponseModel?>> GetNearbyEntriesAsync(string dictCode, string entryId, int entryNumber = 5);

	//getEntryPronunciations
	Task<string> GetEntryPronunciationsJsonAsync(string dictCode, string entryId, string format = "mp3", string lang = "uk");
	Task<ApiResponse<List<EntryPronunciationResponseModel>?>> GetEntryPronunciationsAsync(string dictCode, string entryId, string format = "mp3", string lang = "uk");

	//getRelatedEntries
	//search
	//didYouMean
	//searchFirst
	//getTopics
	//getThesaurus
	//getTopic
	//getDictionaryWordOfTheDay
	//getDictionaryWordOfTheDayPreview
	//getWordOfTheDay
	//getWordOfTheDayPreview
}
