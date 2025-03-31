using CambridgeDictionaryApi.Models.ApiBase;
using System.Net;

namespace CambridgeDictionaryApi.Interfaces;
public interface ICambridgeResponseHandler
{
	ApiResponse<TSuccess> HandleResponse<TSuccess, TError>(HttpStatusCode statusCode, string json)
	   where TError : ApiErrorResponse, new();
}
