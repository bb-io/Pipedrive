using Apps.Pipedrive.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Pipedrive.Models.Request.Person;

public class AddPersonRequest
{
    public string Name { get; set; }

    [Display("Owner")]
    [DataSource(typeof(UserDataHandler))]
    public string? OwnerId { get; set; }

    [Display("Organization")]
    [DataSource(typeof(OrganizationDataHandler))]
    public string? OrgId { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    [Display("Is private")]
    public bool? IsPrivate { get; set; }
}