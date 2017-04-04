using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace CiteThisShit.Data.OpenLibrary
{
    public class Type
    {

        [JsonProperty("key")]
        public string Key { get; set; }
    }

    public class TableOfContent
    {

        [JsonProperty("level")]
        public int Level { get; set; }

        [JsonProperty("type")]
        public Type Type { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }

    public class Contributor
    {

        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class Language
    {

        [JsonProperty("key")]
        public string Key { get; set; }
    }

    public class LastModified
    {

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("value")]
        public DateTime Value { get; set; }
    }

    public class Author
    {

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }
    }

    public class Created
    {

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("value")]
        public DateTime Value { get; set; }
    }

    public class Identifiers
    {

        [JsonProperty("amazon")]
        public IList<string> Amazon { get; set; }

        [JsonProperty("google")]
        public IList<string> Google { get; set; }

        [JsonProperty("goodreads")]
        public IList<string> Goodreads { get; set; }

        [JsonProperty("librarything")]
        public IList<string> Librarything { get; set; }
    }

    public class Work
    {

        [JsonProperty("key")]
        public string Key { get; set; }
    }

    public class Details
    {

        [JsonProperty("number_of_pages")]
        public int NumberOfPages { get; set; }

        [JsonProperty("table_of_contents")]
        public IList<TableOfContent> TableOfContents { get; set; }

        [JsonProperty("weight")]
        public string Weight { get; set; }

        [JsonProperty("covers")]
        public IList<int> Covers { get; set; }

        [JsonProperty("lc_classifications")]
        public IList<string> LcClassifications { get; set; }

        [JsonProperty("latest_revision")]
        public int LatestRevision { get; set; }

        [JsonProperty("ocaid")]
        public string Ocaid { get; set; }

        [JsonProperty("contributors")]
        public IList<Contributor> Contributors { get; set; }

        [JsonProperty("source_records")]
        public IList<string> SourceRecords { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("languages")]
        public IList<Language> Languages { get; set; }

        [JsonProperty("subjects")]
        public IList<string> Subjects { get; set; }

        [JsonProperty("publish_country")]
        public string PublishCountry { get; set; }

        [JsonProperty("by_statement")]
        public string ByStatement { get; set; }

        [JsonProperty("oclc_numbers")]
        public IList<string> OclcNumbers { get; set; }

        [JsonProperty("type")]
        public Type Type { get; set; }

        [JsonProperty("physical_dimensions")]
        public string PhysicalDimensions { get; set; }

        [JsonProperty("revision")]
        public int Revision { get; set; }

        [JsonProperty("publishers")]
        public IList<string> Publishers { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("physical_format")]
        public string PhysicalFormat { get; set; }

        [JsonProperty("last_modified")]
        public LastModified LastModified { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("authors")]
        public IList<Author> Authors { get; set; }

        [JsonProperty("publish_places")]
        public IList<string> PublishPlaces { get; set; }

        [JsonProperty("pagination")]
        public string Pagination { get; set; }

        [JsonProperty("created")]
        public Created Created { get; set; }

        [JsonProperty("lccn")]
        public IList<string> Lccn { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }

        [JsonProperty("identifiers")]
        public Identifiers Identifiers { get; set; }

        [JsonProperty("isbn_13")]
        public IList<string> Isbn13 { get; set; }

        [JsonProperty("dewey_decimal_class")]
        public IList<string> DeweyDecimalClass { get; set; }

        [JsonProperty("isbn_10")]
        public IList<string> Isbn10 { get; set; }

        [JsonProperty("publish_date")]
        public string PublishDate { get; set; }

        [JsonProperty("works")]
        public IList<Work> Works { get; set; }
    }

    public class OpenLibraryResult
    {

        [JsonProperty("info_url")]
        public string InfoUrl { get; set; }

        [JsonProperty("bib_key")]
        public string BibKey { get; set; }

        [JsonProperty("preview_url")]
        public string PreviewUrl { get; set; }

        [JsonProperty("thumbnail_url")]
        public string ThumbnailUrl { get; set; }

        [JsonProperty("details")]
        public Details Details { get; set; }

        [JsonProperty("preview")]
        public string Preview { get; set; }
    }

}
