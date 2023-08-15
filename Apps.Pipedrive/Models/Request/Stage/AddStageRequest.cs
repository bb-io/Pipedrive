using Apps.Pipedrive.Models.Request.Pipeline;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Pipedrive.Models.Request.Stage;

public class AddStageRequest : PipelineRequest
{
    public string Name { get; set; }
   
    [Display("Deal probability")]
    public long? DealProbability { get; set; }

    public bool? Rotten { get; set; }

    [Display("Rotten days")]
    public long? RottenDays { get; set; }
}