using Blackbird.Applications.Sdk.Common;
using Pipedrive;

namespace Apps.Pipedrive.Models.Dto;

public class ActivityDto
{
    [Display("ID")] public string Id { get; set; }

    [Display("Company ID")] public string CompanyId { get; set; }

    [Display("User ID")] public string UserId { get; set; }

    [Display("Is done")] public bool Done { get; set; }

    [Display("Type")] public string Type { get; set; }

    [Display("Reference type")] public string ReferenceType { get; set; }

    [Display("Reference ID")] public string ReferenceId { get; set; }

    [Display("Due date")] public DateTime? DueDate { get; set; }

    [Display("Due time")] public string DueTime { get; set; }

    [Display("Duration")] public string Duration { get; set; }

    [Display("Add time")] public DateTime? AddTime { get; set; }

    [Display("Update time")] public DateTime? UpdateTime { get; set; }

    [Display("Marked as done time")] public DateTime? MarkedAsDoneTime { get; set; }

    [Display("Last notification time")] public DateTime? LastNotificationTime { get; set; }

    [Display("Last notification user ID")] public string? LastNotificationUserId { get; set; }

    [Display("Notification language ID")] public string? NotificationLanguageId { get; set; }

    [Display("Subject")] public string Subject { get; set; }

    [Display("Organization ID")] public string? OrgId { get; set; }

    [Display("Person ID")] public string? PersonId { get; set; }

    [Display("Deal ID")] public string? DealId { get; set; }

    [Display("Is active")] public bool ActiveFlag { get; set; }

    [Display("Update user ID")] public long? UpdateUserId { get; set; }

    [Display("Google calendar event ID")] public string GcalEventId { get; set; }

    [Display("Google calendar ID")] public string GoogleCalendarId { get; set; }

    [Display("Google calendar Etag")] public string GoogleCalendarEtag { get; set; }

    [Display("Note")] public string Note { get; set; }

    [Display("Location")] public string Location { get; set; }

    [Display("Public description")] public string PublicDescription { get; set; }

    [Display("Is busy")] public bool? BusyFlag { get; set; }

    [Display("Created by user ID")] public string CreatedByUserId { get; set; }

    [Display("Participants")] public IEnumerable<ParticipantDto>? Participants { get; set; }

    [Display("Organization Name")] public string OrgName { get; set; }

    [Display("Person name")] public string PersonName { get; set; }

    [Display("Deal title")] public string DealTitle { get; set; }

    [Display("Owner name")] public string OwnerName { get; set; }

    [Display("Assigned to user ID")] public long? AssignedToUserId { get; set; }

    public ActivityDto(AbstractActivity activity)
    {
        Id = activity.Id.ToString();
        CompanyId = activity.CompanyId.ToString();
        UserId = activity.UserId.ToString();
        Done = activity.Done;
        Type = activity.Type;
        ReferenceType = activity.ReferenceType;
        ReferenceId = activity.ReferenceId;
        DueDate = activity.DueDate;
        DueTime = activity.DueTime;
        Duration = activity.Duration;
        AddTime = activity.AddTime;
        UpdateTime = activity.UpdateTime;
        MarkedAsDoneTime = activity.MarkedAsDoneTime;
        LastNotificationTime = activity.LastNotificationTime;
        LastNotificationUserId = activity.LastNotificationUserId.ToString();
        NotificationLanguageId = activity.NotificationLanguageId.ToString();
        Subject = activity.Subject;
        OrgId = activity.OrgId.ToString();
        PersonId = activity.PersonId.ToString();
        DealId = activity.DealId.ToString();
        ActiveFlag = activity.ActiveFlag;
        UpdateUserId = activity.UpdateUserId;
        GcalEventId = activity.GcalEventId;
        GoogleCalendarId = activity.GoogleCalendarId;
        GoogleCalendarEtag = activity.GoogleCalendarEtag;
        Note = activity.Note;
        Location = activity.Location;
        PublicDescription = activity.PublicDescription;
        BusyFlag = activity.BusyFlag;
        CreatedByUserId = activity.CreatedByUserId.ToString();
        Participants = activity.Participants?.Select(x => new ParticipantDto(x));
        OrgName = activity.OrgName;
        PersonName = activity.PersonName;
        DealTitle = activity.DealTitle;
        OwnerName = activity.OwnerName;
        AssignedToUserId = activity.AssignedToUserId;
    }
}