using Apps.Pipedrive.DataSourceHandlers;
using Apps.Pipedrive.DataSourceHandlers.EnumDataHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dictionaries;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Pipedrive.Models.Request.Activity;

public class ManageActivityRequest
{
    public string? Subject { get; set; }

    [Display("Is done")]
    public bool? IsDone { get; set; }
    
    [StaticDataSource(typeof(ActivityTypeDataHandler))]
    public string? Type { get; set; }

    [Display("Due date")]
    public DateTime? DueDate { get; set; }

    [Display("Due time")]
    public string? DueTime { get; set; }

    public string? Duration { get; set; }

    [Display("User")]
    [DataSource(typeof(UserDataHandler))]
    public string? UserId { get; set; }

    [Display("Deal")]
    [DataSource(typeof(DealDataHandler))]
    public string? DealId { get; set; }

    [Display("Person")]
    [DataSource(typeof(PersonDataHandler))]
    public string? PersonId { get; set; }

    [Display("Participant IDs")]
    public IEnumerable<string>? Participants { get; set; }

    [Display("Organization")]
    [DataSource(typeof(OrganizationDataHandler))]
    public string? OrganizationId { get; set; }

    public string? Note { get; set; }

    public string? Location { get; set; }

    [Display("Public description")]
    public string? PublicDescription { get; set; }

    [Display("Is busy")]
    public bool? BusyFlag { get; set; }
}