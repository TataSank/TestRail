using System.Text.Json.Serialization;

namespace TestRail.Models
{
    public class TestCaseModel
    {
        [JsonPropertyName("section_id")] public string SectionId { get; set; }
        [JsonPropertyName("title")] public string title { get; set; }
        [JsonPropertyName("template_id")] public int ShowAnnouncement { get; set; }
        [JsonPropertyName("type_id")] public int type_id { get; set; }
        [JsonPropertyName("priority_id")] public int priority_id { get; set; }
      
    }
}


