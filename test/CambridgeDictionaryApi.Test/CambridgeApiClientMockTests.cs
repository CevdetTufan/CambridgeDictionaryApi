using CambridgeDictionaryApi.Interfaces;
using CambridgeDictionaryApi.Services;
using Moq;

namespace CambridgeDictionaryApi.Test;

public class CambridgeApiClientMockTests
{
	private readonly Mock<ICambridgeRequestHandler> _mockHandler;
	private readonly CambridgeApiClient _client;

	public CambridgeApiClientMockTests()
	{
		_mockHandler = new Mock<ICambridgeRequestHandler>();
		_client = new CambridgeApiClient(_mockHandler.Object);
	}

	[Fact]
	public async Task GetDictionariesJsonAsync_ReturnsExpectedJson()
	{
		// Arrange
		var expectedJson = "[{\"code\":\"english\",\"name\":\"English Dictionary\"}]";
		_mockHandler
			.Setup(h => h.SendGetRequestAsync("dictionaries"))
			.ReturnsAsync(expectedJson);

		// Act
		var result = await _client.GetDictionariesJsonAsync();

		// Assert
		Assert.Equal(expectedJson, result);
	}
}
