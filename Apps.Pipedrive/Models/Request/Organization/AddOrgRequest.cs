using Apps.Pipedrive.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Pipedrive.Models.Request.Organization;

public class AddOrgRequest
{
    public string Name { get; set; }

    [Display("Owner")]
    [DataSource(typeof(UserDataHandler))]
    public string? OwnerId { get; set; }

    [Display("Is private")]
    public bool? IsPrivate { get; set; }
}