namespace CambridgeDictionaryApi.Models;
public class NearbyEntryResponseModel
{
	public string? DictionaryCode { get; set; }
	public List<SearchEntryResponseModel>? NearbyPrecedingEntries { get; set; }
	public string? EntryId { get; set; }
	public List<SearchEntryResponseModel>? NearbyFollowingEntries { get; set; }
}

