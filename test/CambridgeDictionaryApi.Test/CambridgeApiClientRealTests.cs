using CambridgeDictionaryApi.Handlers;
using CambridgeDictionaryApi.Services;

namespace CambridgeDictionaryApi.Test;
public class CambridgeApiClientRealTests
{
	private readonly CambridgeApiClient _client;

	public CambridgeApiClientRealTests()
	{
		var httpClient = new HttpClient
		{
			BaseAddress = new Uri("https://dictionary.cambridge.org/api/v1/")
		};

		string apiKey = "canbridge_dict_api_key";

		var handler = new CambridgeRequestHandler(httpClient, apiKey);

		_client = new CambridgeApiClient(handler);
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


}
