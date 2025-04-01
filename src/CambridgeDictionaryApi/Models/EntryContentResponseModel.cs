using System.Xml.Serialization;

namespace CambridgeDictionaryApi.Models;

[XmlRoot("page", Namespace = "")]
public class EntryContentResponseModel
{
	[XmlElement("metadata")]
	public Metadata? Metadata { get; set; }

	// toc-page elementi içinde <toc-entry> elemanları var.
	[XmlArray("toc-page")]
	[XmlArrayItem("toc-entry")]
	public List<TocEntry>? TocPage { get; set; }

	[XmlElement("pageTitle")]
	public string? PageTitle { get; set; }

	// Birden fazla <dictionary> elemanı mevcut.
	[XmlElement("dictionary")]
	public List<DictionaryData>? Dictionaries { get; set; }

	// dataset elemanı isteğe bağlı
	[XmlElement("dataset")]
	public Dataset? Dataset { get; set; }
}

public class Metadata
{
	// <meta> elemanları
	[XmlElement("meta")]
	public List<string>? Meta { get; set; }
}

public class TocEntry
{
	// <toc-pos-block> elemanları
	[XmlElement("toc-pos-block")]
	public List<TocPosBlock>? TocPosBlocks { get; set; }
}

public class TocPosBlock
{
	[XmlElement("toc-pos")]
	public string? TocPos { get; set; }

	// <toc-sense> elemanları
	[XmlElement("toc-sense")]
	public List<TocSense>? TocSenses { get; set; }
}

public class TocSense
{
	[XmlElement("toc-form")]
	public string? TocForm { get; set; }

	// Bu element her zaman mevcut olmayabilir, dolayısıyla null olmasına izin verebilirsiniz.
	[XmlElement("toc-gw")]
	public string? TocGw { get; set; }
}

public class DictionaryData
{
	[XmlElement("dictName")]
	public string? DictName { get; set; }

	// <di> elemanları
	[XmlElement("di")]
	public List<DictionaryEntry>? Di { get; set; }


}

public class DictionaryEntry
{
	[XmlElement("header")]
	public Header? Header { get; set; }

	// <pos-block> elemanları
	[XmlElement("pos-block")]
	public List<PosBlock>? PosBlocks { get; set; }

	[XmlElement("footer")]
	public Footer? Footer { get; set; }
}

public class Header
{
	[XmlElement("title")]
	public string? Title { get; set; }

	[XmlElement("info")]
	public Info? Info { get; set; }
}

public class Info
{
	[XmlElement("posgram")]
	public PosGram? PosGram { get; set; }

	// Basitçe içeriği string olarak almak için
	[XmlElement("pron")]
	public string? Pron { get; set; }

	// Birden fazla audio elemanı var.
	[XmlElement("audio")]
	public List<Audio>? Audio { get; set; }

	[XmlElement("irreg-infls")]
	public IrregularInflections? IrregInfls { get; set; }
}

public class PosGram
{
	[XmlElement("pos")]
	public string? Pos { get; set; }
}

public class Audio
{
	// Öznitelikler: type ve region
	[XmlAttribute("type")]
	public string? Type { get; set; }

	[XmlAttribute("region")]
	public string? Region { get; set; }

	// <source> elemanlarını içerir.
	[XmlElement("source")]
	public List<AudioSource>? Sources { get; set; }
}

public class AudioSource
{
	[XmlAttribute("type")]
	public string? Type { get; set; }

	[XmlAttribute("src")]
	public string? Src { get; set; }
}

public class IrregularInflections
{
	[XmlElement("inf-group")]
	public List<InflectionGroup>? InfGroups { get; set; }
}

public class InflectionGroup
{
	[XmlElement("lab")]
	public string? Label { get; set; }

	[XmlElement("f")]
	public string? Form { get; set; }
}

public class PosBlock
{
	[XmlElement("header")]
	public Header? Header { get; set; }

	// <sense-block> elemanları
	[XmlElement("sense-block")]
	public List<SenseBlock>? SenseBlocks { get; set; }

	// <entry-xref> elemanları varsa
	[XmlElement("entry-xref")]
	public List<EntryXRef>? EntryXrefs { get; set; }
}

public class SenseBlock
{
	[XmlElement("header")]
	public Header? Header { get; set; }

	[XmlElement("def-block")]
	public List<DefBlock>? DefBlocks { get; set; }
}

public class DefBlock
{
	// senseId attribute'u
	[XmlAttribute("senseId")]
	public string? SenseId { get; set; }

	[XmlElement("definition")]
	public Definition? Definition { get; set; }

	// Birden fazla örnek olabilir.
	[XmlElement("examp")]
	public List<Example>? Examples { get; set; }
}

public class Definition
{
	[XmlElement("info")]
	public DefinitionInfo? Info { get; set; }

	[XmlElement("def")]
	public string? Def { get; set; }

	[XmlElement("trans")]
	public string? Trans { get; set; }
}

public class DefinitionInfo
{
	[XmlElement("lvl")]
	public string? Level { get; set; }
}

public class Example
{
	[XmlElement("eg")]
	public string? Eg { get; set; }
}

public class EntryXRef
{
	[XmlElement("lab")]
	public string? Label { get; set; }

	[XmlElement("x")]
	public List<XRefEntry>? XRefs { get; set; }
}

public class XRefEntry
{
	[XmlAttribute("dictionary")]
	public string? Dictionary { get; set; }

	[XmlAttribute("entryId")]
	public string? EntryId { get; set; }

	// Bir veya birden fazla <f> elemanı olabiliyor
	[XmlElement("f")]
	public List<string>? Forms { get; set; }
}

public class Footer
{
	[XmlElement("copyright")]
	public string? Copyright { get; set; }
}

public class Dataset
{
	[XmlElement("DyCExport")]
	public DyCExport? DyCExport { get; set; }
}

public class DyCExport
{
}

