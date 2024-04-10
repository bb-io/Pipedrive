using Apps.Pipedrive.DataSourceHandlers;
using Apps.Pipedrive.DataSourceHandlers.EnumDataHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dictionaries;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Pipedrive.Models.Request.Deal;

public class ListDealsRequest
{
    [Display("Stage")]
    [DataSource(typeof(StageDataHandler))]
    public string? StageId { get; set; }

    [StaticDataSource(typeof(DealStatusDataHandler))]
    public string? Status { get; set; }
}