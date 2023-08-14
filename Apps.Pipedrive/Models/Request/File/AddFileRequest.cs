using Apps.Pipedrive.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Pipedrive.Models.Request.File;

public class AddFileRequest
{
    [Display("File name")] public string FileName { get; set; }

    [Display("File content")] public byte[] FileContent { get; set; }

    [Display("Content type")] public string ContentType { get; set; }

    [Display("Deal")]
    [DataSource(typeof(DealDataHandler))]
    public string? DealId { get; set; }

    [Display("Person")] 
    [DataSource(typeof(PersonDataHandler))]
    public string? PersonId { get; set; }

    [Display("Organization")] 
    [DataSource(typeof(OrganizationDataHandler))]
    public string? OrgId { get; set; }

    [Display("Product")] 
    [DataSource(typeof(ProductDataHandler))]
    public string? ProductId { get; set; }

    [Display("Activity")] 
    [DataSource(typeof(ActivityDataHandler))]
    public string? ActivityId { get; set; }

    [Display("Note")] 
    [DataSource(typeof(NoteDataHandler))]
    public string? NoteId { get; set; }
}