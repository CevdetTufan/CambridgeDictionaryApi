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
	Task<string> GetRelatedEntriesJsonAsync(string dictCode, string entryId);
	Task<ApiResponse<RelatedEntryResponseModel?>> GetRelatedEntriesAsync(string dictCode, string entryId);

	//search
	Task<string> SearchJsonAsync(string dictCode, string query, int pageSize = 10, int pageIndex = 1);
	Task<ApiResponse<SearchResponseModel?>> SearchAsync(string dictCode, string query, int pageSize = 10, int pageIndex = 1);

	//didYouMean
	Task<string> DidYouMeanJsonAsync(string dictCode, string query, int entryNumber = 10);
	Task<ApiResponse<DidYouMeanResponseModel?>> DidYouMeanAsync(string dictCode, string query, int entryNumber = 10);

	//searchFirst
	Task<string> SearchFirstJsonAsync(string dictCode, string query, string format = "xml");
	Task<ApiResponse<EntryResponseModel?>> SearchFirstAsync(string dictCode, string query, string format = "xml");

	//getTopics
	Task<string> GetTopicsJsonAsync(string dictCode);
	Task<ApiResponse<List<TopicResponseModel>?>> GetTopicsAsync(string dictCode);

	//getThesaurus
	Task<string> GetThesaurusJsonAsync(string dictCode, string thesaurusName);

	//getDictionaryWordOfTheDay

	Task<string> GetDictionaryWordOfTheDayJsonAsync(string dictCode, string day, string format = "xml");

	//getDictionaryWordOfTheDayPreview
	Task<string> GetDictionaryWordOfTheDayPreviewJsonAsync(string dictCode, string day, string format = "xml");

	//getWordOfTheDay
	Task<string> GetWordOfTheDayJsonAsync(string day, string format = "xml");

	Task<ApiResponse<EntryResponseModel?>> GetWordOfTheDayAsync(string day, string format = "xml");

	//getWordOfTheDayPreview
	Task<string> GetWordOfTheDayPreviewJsonAsync(string day, string format = "xml");

	Task<ApiResponse<WordOfTheDayPreviewResponseModel?>> GetWordOfTheDayPreviewAsync(string day, string format = "xml");
}
