using Blackbird.Applications.Sdk.Common;
using Pipedrive;

namespace Apps.Pipedrive.Models.Dto;

public class NoteDto
{
    [Display("ID")] public string Id { get; set; }

    [Display("User ID")] public string? UserId { get; set; }

    [Display("Deal ID")] public string? DealId { get; set; }

    [Display("Person ID")] public string? PersonId { get; set; }

    [Display("Organization ID")] public string? OrgId { get; set; }

    public string Content { get; set; }

    [Display("Add time")] public DateTime? AddTime { get; set; }

    public NoteDto(Note note)
    {
        Id = note.Id.ToString();
        UserId = note.UserId.ToString();
        DealId = note.DealId.ToString();
        PersonId = note.PersonId.ToString();
        OrgId = note.OrgId.ToString();
        Content = note.Content;
        AddTime = note.AddTime;
    }
}