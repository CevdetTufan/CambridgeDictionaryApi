using CambridgeDictionaryApi.Models;
using System.Xml.Linq;

namespace CambridgeDictionaryApi.Extensions;
public static class XmlExtensions
{
	public static bool TryParseEntryContent(this string xml, out EntryContentResponseModel? model)
	{
		try
		{
			XDocument doc = XDocument.Parse(xml);
			XElement? root = doc.Root;
			if (root == null)
			{
				model = null;
				return false;
			}

			model = new EntryContentResponseModel
			{
				// pageTitle öğesini alıyoruz
				PageTitle = root.Element("pageTitle")?.Value ?? string.Empty,

				// Metadata: <metadata> içindeki tüm <meta> elemanlarının değerlerini alıyoruz
				Metadata = new Metadata
				{
					Meta = root.Element("metadata")?
						  .Elements("meta")
						  .Select(x => x.Value)
						  .ToList() ?? []
				},

				// TocPage: <toc-page> altındaki <toc-entry> elemanlarından map ediyoruz
				TocPage = root.Element("toc-page")?
					   .Elements("toc-entry")
					   .Select(te => new TocEntry
					   {
						   TocPosBlocks = te.Elements("toc-pos-block")
											.Select(tp => new TocPosBlock
											{
												TocPos = tp.Element("toc-pos")?.Value,
												TocSenses = tp.Elements("toc-sense")
															  .Select(ts => new TocSense
															  {
																  TocForm = ts.Element("toc-form")?.Value,
																  TocGw = ts.Element("toc-gw")?.Value
															  }).ToList()
											}).ToList()
					   }).ToList() ?? new List<TocEntry>(),

				// Dictionaries: Her <dictionary> elemanını map ediyoruz
				Dictionaries = root.Elements("dictionary")
							  .Select(dict => new DictionaryData
							  {
								  DictName = dict.Element("dictName")?.Value,
								  Di = dict.Elements("di")
										   .Select(di => new DictionaryEntry
										   {
											   Header = new Header
											   {
												   Title = di.Element("header")?.Element("title")?.Value,
												   // Info, vs. alanları burada da map edebilirsiniz...
											   },
											   // Daha detaylı mapleme için PosBlocks ve Footer da eklenebilir.
											   PosBlocks = di.Elements("pos-block")
															.Select(pb => new PosBlock
															{
																// Örneğin sadece header'ı map edelim
																Header = new Header
																{
																	Title = pb.Element("header")?.Element("info")?
																			   .Element("posgram")?
																			   .Element("pos")?.Value
																},
																// SenseBlocks ve EntryXrefs eklenebilir
																SenseBlocks = pb.Elements("sense-block")
																				.Select(sb => new SenseBlock
																				{
																					Header = new Header
																					{
																						Title = sb.Element("header")?.Element("title")?.Value
																					},
																					DefBlocks = sb.Elements("def-block")
																								  .Select(db => new DefBlock
																								  {
																									  SenseId = db.Attribute("senseId")?.Value,
																									  Definition = new Definition
																									  {
																										  Def = db.Element("definition")?.Element("def")?.Value,
																										  Trans = db.Element("definition")?.Element("trans")?.Value,
																										  Info = new DefinitionInfo
																										  {
																											  Level = db.Element("definition")?
																													.Element("info")?
																													.Element("lvl")?.Value
																										  }
																									  },
																									  Examples = db.Elements("examp")
																												   .Select(ex => new Example
																												   {
																													   Eg = ex.Element("eg")?.Value
																												   }).ToList()
																								  }).ToList()
																				}).ToList(),
																EntryXrefs = pb.Elements("entry-xref")
																			   .Select(er => new EntryXRef
																			   {
																				   Label = er.Element("lab")?.Value,
																				   XRefs = er.Elements("x")
																							 .Select(x => new XRefEntry
																							 {
																								 Dictionary = x.Attribute("dictionary")?.Value,
																								 EntryId = x.Attribute("entryId")?.Value,
																								 // Birden fazla <f> varsa, listeye alabilirsiniz.
																								 Forms = x.Elements("f")
																										   .Select(f => f.Value)
																										   .ToList()
																							 }).ToList()
																			   }).ToList()
															}).ToList(),
											   Footer = new Footer
											   {
												   Copyright = di.Element("footer")?.Element("copyright")?.Value
											   }
										   }).ToList()
							  }).ToList(),

				// Dataset: İsteğe bağlı, örneğin
				Dataset = new Dataset
				{
					DyCExport = new DyCExport()					
				}
			};
		}
		catch
		{
			model = null;
			return false;
		}

		return true;
	}
}
