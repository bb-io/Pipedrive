using Blackbird.Applications.Sdk.Common;

namespace Apps.Pipedrive.Models.Request.Activity;

public class MnageActivityRequest
{
    public string? Subject { get; set; }

    [Display("Is done")]
    public bool? IsDone { get; set; }

    public string? Type { get; set; }

    [Display("Due date")]
    public DateTime? DueDate { get; set; }

    [Display("Due time")]
    public string? DueTime { get; set; }

    public string? Duration { get; set; }

    [Display("User ID")]
    public string? UserId { get; set; }

    [Display("Deal ID")]
    public string? DealId { get; set; }

    [Display("Person ID")]
    public string? PersonId { get; set; }

    [Display("Participant IDs")]
    public IEnumerable<string> Participants { get; set; }

    [Display("Organization ID")]
    public string? OrganizationId { get; set; }

    public string? Note { get; set; }

    public string? Location { get; set; }

    [Display("Public description")]
    public string? PublicDescription { get; set; }

    [Display("Is busy")]
    public bool? BusyFlag { get; set; }
}