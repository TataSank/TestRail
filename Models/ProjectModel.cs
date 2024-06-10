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
        [JsonPropertyName("completed_on")] public int? CompletedOn { get; set; }
        [JsonPropertyName("default_role_id")] public int? DefaultRoleId { get; set; }
        [JsonPropertyName("case_statuses_enabled")] public bool CaseStatusesEnabled { get; set; }
        [JsonPropertyName("url")] public string Url { get; set; }
        [JsonPropertyName("users")] public object[] Users { get; set; }
        [JsonPropertyName("groups")] public object[] Groups { get; set; }


        public override string ToString()
        {
            return $"{nameof(Name)}:{Name},{nameof(Announcement)}:{Announcement},{nameof(ShowAnnouncement)}:{ShowAnnouncement}," +
                $"{nameof(SuiteMode)}:{SuiteMode},{nameof(Id)}:{Id},{nameof(CompletedOn)}:{CompletedOn},{nameof(DefaultRoleId)}:{DefaultRoleId}," +
                $"{nameof(CaseStatusesEnabled)}:{CaseStatusesEnabled},{nameof(Url)}:{Url},{nameof(Users)}:{Users},{nameof(Groups)}:{Groups}";


        }
        public bool Equals(ProjectModel projectModel)
        {
            return Name == projectModel.Name && Announcement == projectModel.Announcement && SuiteMode == projectModel.SuiteMode && Id == projectModel.Id
             && CompletedOn == projectModel.CompletedOn && DefaultRoleId == projectModel.DefaultRoleId && CaseStatusesEnabled == projectModel.CaseStatusesEnabled &&
             Url == projectModel.Url && Equals(Users, projectModel.Users) && Equals(Groups, projectModel.Groups); 
        }
        
    }
}
