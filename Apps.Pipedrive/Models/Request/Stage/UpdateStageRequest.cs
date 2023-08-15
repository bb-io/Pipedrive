using Apps.Pipedrive.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Pipedrive.Models.Request.Stage;

public class UpdateStageRequest : AddStageRequest
{
    public new string? Name { get; set; }
    
    [Display("Pipeline")]
    [DataSource(typeof(PipelineDataHandler))]
    public new string? PipelineId { get; set; }
}