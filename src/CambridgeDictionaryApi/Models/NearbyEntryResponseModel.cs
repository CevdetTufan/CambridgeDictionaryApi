namespace CambridgeDictionaryApi.Models;
public class NearbyEntryResponseModel
{
	public string? DictionaryCode { get; set; }
	public List<NearbyPrecedingEntryResponseModel>? NearbyPrecedingEntries { get; set; }
	public string? EntryId { get; set; }
	public List<NearbyFollowingEntryResponseModel>? NearbyFollowingEntries { get; set; }
}

public class NearbyFollowingEntryResponseModel
{
	public string? EntryLabel { get; set; }
	public string? EntryUrl { get; set; }
	public string? EntryId { get; set; }
}

public class NearbyPrecedingEntryResponseModel
{
	public string? EntryLabel { get; set; }
	public string? EntryUrl { get; set; }
	public string? EntryId { get; set; }
}

