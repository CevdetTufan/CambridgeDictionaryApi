namespace CambridgeDictionaryApi.Models;

public class DidYouMeanResponseModel
{
	public string? SearchTerm { get; set; }
	public string? DictionaryCode { get; set; }
	public List<string>? Suggestions { get; set; }
}
