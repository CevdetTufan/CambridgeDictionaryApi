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

		string apiKey = configuration["Cambridge:ApiKey"];
		string baseUrl = configuration["Cambridge:BaseUrl"];

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

		if(result.Data?.EntryContent == null)
		{
			Assert.True(false);
			return;
		}

		bool deserialized = result.Data.EntryContent.TryParseEntryContent(out var entryContent);

		Assert.True(deserialized);
		Assert.NotNull(entryContent);
	}
}
