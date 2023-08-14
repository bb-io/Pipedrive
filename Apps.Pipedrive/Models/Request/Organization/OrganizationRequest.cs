using Apps.Pipedrive.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Pipedrive.Models.Request.Organization;

public class OrganizationRequest
{
    [Display("Organization")]
    [DataSource(typeof(OrganizationDataHandler))]
    public string OrgId { get; set; }
}