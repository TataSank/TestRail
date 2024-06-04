using System.Text.Json.Serialization;


namespace TestRail.Models
{
    public class ProjectModel
    {
        [JsonPropertyName("name")] public string Name { get; set; }
        [JsonPropertyName("announcement")] public string Announcement { get; set; }
        [JsonPropertyName("show_announcement")] public bool ShowAnnouncement { get; set; }
        [JsonPropertyName("suite_mode")] public int SuiteMode { get; set; }
        [JsonPropertyName("id")] public int Id { get; set; }

        public override string ToString()
        {
            return $"{nameof(Name)}:{Name},{nameof(Announcement)}:{Announcement},{nameof(ShowAnnouncement)}:{ShowAnnouncement},{nameof(SuiteMode)}:{SuiteMode},{nameof(Id)}:{Id}";
        }
        public bool Equals(ProjectModel projectModel)
        {
            return Name == projectModel.Name && Announcement == projectModel.Announcement && SuiteMode == projectModel.SuiteMode;
        }
    }
}
