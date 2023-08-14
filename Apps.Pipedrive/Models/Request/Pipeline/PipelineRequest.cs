using Apps.Pipedrive.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Pipedrive.Models.Request.Pipeline;

public class PipelineRequest
{
    [Display("Pipeline")]
    [DataSource(typeof(PipelineDataHandler))]
    public string PipelineId { get; set; }
}