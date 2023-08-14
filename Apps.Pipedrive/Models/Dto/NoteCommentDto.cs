using Apps.Pipedrive.Models.Response.NoteComment;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Pipedrive.Models.Dto;

public class NoteCommentDto
{
    [Display("UUID")] public string Uuid { get; set; }

    [Display("Is active")] public bool IsActive { get; set; }

    [Display("Add time")] public DateTime AddTime { get; set; }

    [Display("Company ID")] public string CompanyId { get; set; }

    [Display("Object ID")] public string ObjectId { get; set; }

    public string Content { get; set; }

    public NoteCommentDto(NoteCommentResponse comment)
    {
        Uuid = comment.Uuid;
        IsActive = comment.IsActive;
        AddTime = comment.AddTime;
        CompanyId = comment.CompanyId;
        ObjectId = comment.ObjectId;
        Content = comment.Content;
    }
}