namespace CambridgeDictionaryApi.Models;

public class SearchResponseModel
{
	public int PageNumber { get; set; }
	public string? DictionaryCode { get; set; }
	public int ResultNumber { get; set; }
	public int? CurrentPageIndex { get; set; }
	public List<SearchEntryResponseModel>? Results { get; set; }
}

public class SearchEntryResponseModel
{
	public string? EntryLabel { get; set; }
	public string? EntryUrl { get; set; }
	public string? EntryId { get; set; }
}
