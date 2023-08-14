using Apps.Pipedrive.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Pipedrive.Models.Request.Note;

public class AddNoteRequest
{
    public string Content { get; set; }

    [Display("Deal")]
    [DataSource(typeof(DealDataHandler))]
    public string? DealId { get; set; }

    [Display("Person")]
    [DataSource(typeof(PersonDataHandler))]
    public string? PersonId { get; set; }

    [Display("Organization")]
    [DataSource(typeof(OrganizationDataHandler))]
    public string? OrgId { get; set; }

    [Display("Pinned to deal")]
    public bool? PinnedToDeal { get; set; }

    [Display("Pinned to organization")]
    public bool? PinnedToOrganization { get; set; }

    [Display("Pinned to person")]
    public bool? PinnedToPerson { get; set; }
}