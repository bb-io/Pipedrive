using Apps.Pipedrive.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Pipedrive.Models.Request.Note;

public class ListNotesRequest
{
    [Display("User")]
    [DataSource(typeof(UserDataHandler))]
    public string? UserId { get; set; }

    [Display("Deal")]
    [DataSource(typeof(DealDataHandler))]
    public string? DealId { get; set; }

    [Display("Person")]
    [DataSource(typeof(PersonDataHandler))]
    public string? PersonId { get; set; }

    [Display("Organization")]
    [DataSource(typeof(OrganizationDataHandler))]
    public string? OrgId { get; set; }
    
    [Display("Start date")]
    public DateTime? StartDate { get; set; }

    [Display("End date")]
    public DateTime? EndDate { get; set; }
}