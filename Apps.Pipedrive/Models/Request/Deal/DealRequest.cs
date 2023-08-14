using Apps.Pipedrive.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Pipedrive.Models.Request.Deal;

public class DealRequest
{
    [Display("Deal")]
    [DataSource(typeof(DealDataHandler))]
    public string DealId { get; set; }
}