using Apps.Pipedrive.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Pipedrive.Models.Request.Stage;

public class StageRequest
{
    [Display("Stage")]
    [DataSource(typeof(StageDataHandler))]
    public string StageId { get; set; }

}