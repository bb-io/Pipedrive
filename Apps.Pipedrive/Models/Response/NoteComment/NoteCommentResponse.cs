using Newtonsoft.Json;

namespace Apps.Pipedrive.Models.Response.NoteComment;

public class NoteCommentResponse
{
    public string Uuid { get; set; }
    
    [JsonProperty("active_flag")]
    public bool IsActive { get; set; }
    
    [JsonProperty("add_time")]
    public DateTime AddTime { get; set; }
    
    [JsonProperty("company_id")]
    public string CompanyId { get; set; }
    
    [JsonProperty("object_id")]
    public string ObjectId { get; set; }
    
    public string Content { get; set; }
}