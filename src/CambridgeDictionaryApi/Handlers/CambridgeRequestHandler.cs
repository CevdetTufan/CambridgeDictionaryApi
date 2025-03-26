using CambridgeDictionaryApi.Interfaces;
using System.Net;

namespace CambridgeDictionaryApi.Handlers;

public class CambridgeRequestHandler : ICambridgeRequestHandler
{
	private readonly HttpClient _httpClient;
	private readonly string _accessKey;

	public CambridgeRequestHandler(HttpClient httpClient, string accessKey)
	{
		_httpClient = httpClient;
		_accessKey = accessKey;
	}

	async Task<string> ICambridgeRequestHandler.SendGetRequestAsync(string endpoint)
	{
		var request = new HttpRequestMessage(HttpMethod.Get, endpoint);
		request.Headers.Add("AccessKey", _accessKey);

		var response = await _httpClient.SendAsync(request);
		return await response.Content.ReadAsStringAsync();
	}

	public async Task<(HttpStatusCode StatusCode, string Content)> SendGetRequestWithStatusAsync(string endpoint)
	{
		var request = new HttpRequestMessage(HttpMethod.Get, endpoint);
		request.Headers.Add("AccessKey", _accessKey);

		var response = await _httpClient.SendAsync(request);

		return (response.StatusCode, await response.Content.ReadAsStringAsync());
	}

}
