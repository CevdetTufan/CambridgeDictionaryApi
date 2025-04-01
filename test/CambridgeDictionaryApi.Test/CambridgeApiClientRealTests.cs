using CambridgeDictionaryApi.Extensions;
using CambridgeDictionaryApi.Handlers;
using CambridgeDictionaryApi.Services;
using Microsoft.Extensions.Configuration;

namespace CambridgeDictionaryApi.Test;
public class CambridgeApiClientRealTests
{
	private readonly CambridgeApiClient _client;

	public CambridgeApiClientRealTests()
	{
		var configuration = new ConfigurationBuilder()
			.AddUserSecrets<CambridgeApiClientRealTests>()
			.Build();

		string apiKey = configuration["CambridgeApi:ApiKey"];
		string baseUrl = configuration["CambridgeApi:BaseUrl"];

		var requestHandler = new CambridgeRequestHandler(new HttpClient { BaseAddress = new Uri(baseUrl) }, apiKey);
		var responseHandler = new CambridgeResponseHandler();
		_client = new CambridgeApiClient(requestHandler, responseHandler);
	}

	//getDictionaries 
	[Fact]
	public async Task GetDictionaries_RealRequest_ReturnsList_Json()
	{
		var result = await _client.GetDictionariesJsonAsync();
		Assert.Contains("dictionary", result.ToLower());
	}

	[Fact]
	public async Task GetDictionaries_RealRequest_ReturnsList()
	{
		var result = await _client.GetDictionariesAsync();
		Assert.True(result != null && result.Data?.Count > 0);
	}

	//getDictionary
	[Fact]
	public async Task GetDictionary_RealRequest_ReturnsDictionary_Json()
	{
		var result = await _client.GetDictionaryJsonAsync("english");
		Assert.Contains("dictionary", result.ToLower());
	}

	[Fact]
	public async Task GetDictionary_RealRequest_ReturnsDictionary()
	{
		var result = await _client.GetDictionaryAsync("british");
		Assert.True(result != null && result.Data != null);
	}

	[Fact]
	public async Task GetDictionary_RealRequest_InvalidDictionary()
	{
		var result = await _client.GetDictionaryAsync("britisht");
		Assert.True(result != null && result.Error?.ErrorCode == "InvalidDictionary");
	}

	//getEntries
	[Fact]
	public async Task GetEntries_RealRequest_ReturnsEntries_Json()
	{
		var result = await _client.GetEntriesJsonAsync("english");
		Assert.Contains("entries", result.ToLower());
	}

	[Fact]
	public async Task GetEntries_RealRequest_ReturnsEntries()
	{
		var result = await _client.GetEntriesAsync("british");
		Assert.True(result != null && result.Data?.Count > 0);
	}

	[Fact]
	public async Task GetEntry_Format_Test()
	{
		var result = await _client.GetEntryJsonAsync("english-turkish", "stand");
		Assert.Contains("entry", result.ToLower());
	}

	[Fact]
	public async Task GetEntry_RealRequest_ReturnsEntry()
	{
		var result = await _client.GetEntryAsync("english-turkish", "stand");
		Assert.True(result != null && result.Data != null);
	}

	[Fact]
	public async Task GetEntry_RealRequest_EntryContextXmlTo()
	{
		var result = await _client.GetEntryAsync("english-turkish", "stand");

		if (result.Data?.EntryContent == null)
		{
			Assert.True(false);
			return;
		}

		bool deserialized = result.Data.EntryContent.TryParseEntryContent(out var entryContent);

		Assert.True(deserialized);
		Assert.NotNull(entryContent);
	}

	//getNearbyEntries
	[Fact]
	public async Task GetNearbyEntries_RealRequest_ReturnsEntries_Json()
	{
		var result = await _client.GetNearbyEntriesJsonAsync("english-turkish", "stand", 10);
		Assert.Contains("entries", result.ToLower());
	}

	[Fact]
	public async Task GetNearbyEntries_RealRequest_ReturnsEntries()
	{
		var result = await _client.GetNearbyEntriesAsync("english-turkish", "stand", 10);
		Assert.True(result != null && result.Data != null);
	}

	//getEntryPronunciations
	[Fact]
	public async Task GetEntryPronunciations_RealRequest_ReturnsPronunciations_Json()
	{
		var result = await _client.GetEntryPronunciationsJsonAsync("british", "stand");
		Assert.Contains("pronunciations", result.ToLower());
	}

	[Fact]
	public async Task GetEntryPronunciations_RealRequest_ReturnsPronunciations()
	{
		var result = await _client.GetEntryPronunciationsAsync("british", "stand", "", "");
		Assert.True(result != null && result.Data?.Count > 0);
	}

	//getRelatedEntries
	[Fact]
	public async Task GetRelatedEntries_RealRequest_ReturnsEntries_Json()
	{
		var result = await _client.GetRelatedEntriesJsonAsync("english-turkish", "stand");
		Assert.Contains("entries", result.ToLower());
	}

	[Fact]
	public async Task GetRelatedEntries_RealRequest_ReturnsEntries()
	{
		var result = await _client.GetRelatedEntriesAsync("english-turkish", "stand");
		Assert.True(result != null && result.Data != null);
	}

	//search
	[Fact]
	public async Task Search_RealRequest_ReturnsEntries_Json()
	{
		var result = await _client.SearchJsonAsync("english-turkish", "stand", 10, 1);
		Assert.Contains("entries", result.ToLower());
	}

	[Fact]
	public async Task Search_RealRequest_ReturnsEntries()
	{
		var result = await _client.SearchAsync("english-turkish", "stand", 10, 1);
		Assert.True(result != null && result.Data != null);
	}

	//didYouMean
	[Fact]
	public async Task DidYouMean_RealRequest_ReturnsEntries_Json()
	{
		var result = await _client.DidYouMeanJsonAsync("english-turkish", "stand", 10);
		Assert.Contains("entries", result.ToLower());
	}

	[Fact]
	public async Task DidYouMean_RealRequest_ReturnsEntries()
	{
		var result = await _client.DidYouMeanAsync("english-turkish", "stand", 10);
		Assert.True(result != null && result.Data != null);
	}

	//searchFirst
	[Fact]
	public async Task SearchFirst_RealRequest_ReturnsEntries_Json()
	{
		var result = await _client.SearchFirstJsonAsync("english-turkish", "stand");
		Assert.Contains("entries", result.ToLower());
	}

	[Fact]
	public async Task SearchFirst_RealRequest_ReturnsEntries()
	{
		var result = await _client.SearchFirstAsync("english-turkish", "stand");
		Assert.True(result != null && result.Data != null);
	}

	[Fact]
	public async Task SearchFirst_RealRequest_EntryContextXmlTo()
	{
		var result = await _client.SearchFirstAsync("english-turkish", "stand");

		if (result.Data?.EntryContent == null)
		{
			Assert.True(false);
			return;
		}

		bool deserialized = result.Data.EntryContent.TryParseEntryContent(out var entryContent);

		Assert.True(deserialized);
		Assert.NotNull(entryContent);
	}

	//getTopics
	[Fact]
	public async Task GetTopics_RealRequest_ReturnsTopics_Json()
	{
		var result = await _client.GetTopicsJsonAsync("english-turkish");
		Assert.Contains("topics", result.ToLower());
	}

	[Fact]
	public async Task GetTopics_RealRequest_ReturnsTopics()
	{
		var result = await _client.GetTopicsAsync("english-turkish");
		Assert.True(result != null && result.Data?.Count > 0);
	}

	//getThesaurus
	[Fact]
	public async Task GetThesaurusJsonAsync_Test()
	{
		var result = await _client.GetThesaurusJsonAsync("english", "topics");
		Assert.Contains("topics", result.ToLower());
	}

	//getDictionaryWordOfTheDay
	[Fact]
	public async Task GetDictionaryWordOfTheDayJsonAsync_Test()
	{
		var result = await _client.GetDictionaryWordOfTheDayJsonAsync("british", "2025-04-01", "xml");
		Assert.Contains("word", result.ToLower());
	}

	//getDictionaryWordOfTheDayPreview
	[Fact]
	public async Task GetDictionaryWordOfTheDayPreviewJsonAsync_Test()
	{
		var result = await _client.GetDictionaryWordOfTheDayPreviewJsonAsync("british", "2025-03-31", "xml");
		Assert.Contains("word", result.ToLower());
	}

	//getWordOfTheDay
	[Fact]
	public async Task GetWordOfTheDay_Test()
	{
		var result = await _client.GetWordOfTheDayJsonAsync( "2025-03-31", "xml");
		Assert.True(result != null);
	}

	[Fact]
	public async Task GetWordOfTheDay_ReturnsWord()
	{
		var result = await _client.GetWordOfTheDayAsync("2025-03-31", "xml");
		Assert.True(result != null && result.Data != null);
	}

	//getWordOfTheDayPreview
	[Fact]
	public async Task GetWordOfTheDayPreviewJsonAsync_Test()
	{
		var result = await _client.GetWordOfTheDayPreviewJsonAsync("2025-03-31", "xml");
		Assert.True(result != null);
	}

	[Fact]
	public async Task GetWordOfTheDayPreviewAsync_ReturnsWord()
	{
		var result = await _client.GetWordOfTheDayPreviewAsync("2025-04-02", "xml");
		Assert.True(result != null && result.Data != null);
	}
}
