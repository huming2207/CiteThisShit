using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace CiteThisShit.Data.Doi
{
    [JsonObject]
    public class Indexed
    {
        [JsonProperty("date-parts")]
        public List<List<int>> DateParts { get; set; }

        [JsonProperty("date-time")]
        public DateTime DateTime { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }
    }

    [JsonObject]
    public class StartTime
    {
        [JsonProperty("date-parts")]
        public List<List<int>> DateParts { get; set; }

        [JsonProperty("date-time")]
        public DateTime DateTime { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }
    }

    [JsonObject]
    public class License
    {
        [JsonProperty("URL")]
        public string Url { get; set; }

        [JsonProperty("start")]
        public StartTime StartTime { get; set; }

        [JsonProperty("delay-in-days")]
        public int DelayInDays { get; set; }

        [JsonProperty("content-version")]
        public string ContentVersion { get; set; }
    }

    [JsonObject]
    public class ContentDomain
    {
        [JsonProperty("domain")]
        public List<object> Domain { get; set; }

        [JsonProperty("crossmark-restriction")]
        public bool CrossmarkRestriction { get; set; }
    }

    [JsonObject]
    public class Created
    {
        [JsonProperty("date-parts")]
        public List<List<int>> DateParts { get; set; }

        [JsonProperty("date-time")]
        public DateTime DateTime { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }
    }

    [JsonObject]
    public class Author
    {
        [JsonProperty("given")]
        public string Given { get; set; }

        [JsonProperty("family")]
        public string Family { get; set; }

        [JsonProperty("affiliation")]
        public List<object> Affiliation { get; set; }
    }

    [JsonObject]
    public class PublishedOnline
    {
        [JsonProperty("date-parts")]
        public List<List<int>> DateParts { get; set; }
    }

    [JsonObject]
    public class Link
    {
        [JsonProperty("URL")]
        public string Url { get; set; }

        [JsonProperty("content-type")]
        public string ContentType { get; set; }

        [JsonProperty("content-version")]
        public string ContentVersion { get; set; }

        [JsonProperty("intended-application")]
        public string IntendedApplication { get; set; }
    }

    [JsonObject]
    public class Deposited
    {
        [JsonProperty("date-parts")]
        public List<List<int>> DateParts { get; set; }

        [JsonProperty("date-time")]
        public DateTime DateTime { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }
    }

    [JsonObject]
    public class Issued
    {

        [JsonProperty("date-parts")]
        public List<List<int>> DateParts { get; set; }
    }

    [JsonObject]
    public class IssnType
    {

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    [JsonObject]
    public class Message
    {

        [JsonProperty("indexed")]
        public Indexed Indexed { get; set; }

        [JsonProperty("reference-count")]
        public int ReferenceCount { get; set; }

        [JsonProperty("publisher")]
        public string Publisher { get; set; }

        [JsonProperty("issue")]
        public string Issue { get; set; }

        [JsonProperty("license")]
        public List<License> License { get; set; }

        [JsonProperty("content-domain")]
        public ContentDomain ContentDomain { get; set; }

        [JsonProperty("short-container-title")]
        public List<object> ShortContainerTitle { get; set; }

        [JsonProperty("cited-count")]
        public int CitedCount { get; set; }

        [JsonProperty("DOI")]
        public string Doi { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("created")]
        public Created Created { get; set; }

        [JsonProperty("page")]
        public string Page { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("title")]
        public List<string> Title { get; set; }

        [JsonProperty("prefix")]
        public string Prefix { get; set; }

        [JsonProperty("volume")]
        public string Volume { get; set; }

        [JsonProperty("author")]
        public List<Author> Author { get; set; }

        [JsonProperty("member")]
        public string Member { get; set; }

        [JsonProperty("published-online")]
        public PublishedOnline PublishedOnline { get; set; }

        [JsonProperty("container-title")]
        public List<string> ContainerTitle { get; set; }

        [JsonProperty("original-title")]
        public List<object> OriginalTitle { get; set; }

        [JsonProperty("link")]
        public List<Link> Link { get; set; }

        [JsonProperty("deposited")]
        public Deposited Deposited { get; set; }

        [JsonProperty("score")]
        public double Score { get; set; }

        [JsonProperty("subtitle")]
        public List<object> Subtitle { get; set; }

        [JsonProperty("short-title")]
        public List<object> ShortTitle { get; set; }

        [JsonProperty("issued")]
        public Issued Issued { get; set; }

        [JsonProperty("URL")]
        public string Url { get; set; }

        [JsonProperty("ISSN")]
        public List<string> Issn { get; set; }

        [JsonProperty("issn-type")]
        public List<IssnType> IssnType { get; set; }

        [JsonProperty("citing-count")]
        public int CitingCount { get; set; }

        [JsonProperty("subject")]
        public List<string> Subject { get; set; }
    }

    [JsonObject]
    public class DoiResult
    {

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message-type")]
        public string MessageType { get; set; }

        [JsonProperty("message-version")]
        public string MessageVersion { get; set; }

        [JsonProperty("message")]
        public Message Message { get; set; }
    }
}
