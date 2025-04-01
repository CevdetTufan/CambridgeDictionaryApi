namespace CambridgeDictionaryApi.Models;
public class RelatedEntryResponseModel
{
	public List<RelatedEntryItemResponseModel>? RelatedEntries { get; set; }
	public string? DictionaryCode { get; set; }
	public string? EntryId { get; set; }
}

public class RelatedEntryItemResponseModel
{
	public string? EntryLabel { get; set; }
	public string? DictionaryName { get; set; }
	public string? EntryUrl { get; set; }
	public string? DictionaryCode { get; set; }
	public string? EntryId { get; set; }
}
