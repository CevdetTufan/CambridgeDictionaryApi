using System.Net;

namespace CambridgeDictionaryApi.Interfaces;

public interface ICambridgeRequestHandler
{
	Task<string> SendGetRequestAsync(string endpoint);
	Task<(HttpStatusCode StatusCode, string Content)> SendGetRequestWithStatusAsync(string endpoint);
}
