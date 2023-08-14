using Apps.Pipedrive.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Pipedrive.Models.Request.Activity;

public class ActivityRequest
{
    [Display("Activity")]
    [DataSource(typeof(ActivityDataHandler))]
    public string ActivityId { get; set; }
}