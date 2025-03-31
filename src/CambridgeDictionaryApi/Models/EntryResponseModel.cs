namespace CambridgeDictionaryApi.Models;
public class EntryResponseModel
{
	public string? DictionaryCode { get; set; }
	public string? EntryContent { get; set; }
	public string? EntryId { get; set; }
	public string? EntryLabel { get; set; }
	public string? EntryUrl { get; set; }
	public string? Format { get; set; }
	public List<TopicResponseModel>? Topics { get; set; }
}