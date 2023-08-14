using Blackbird.Applications.Sdk.Common;

namespace Apps.Pipedrive.Models.Request.Pipeline;

public class AddPipelineRequest
{
    public string Name { get; set; }

    [Display("Order number")]
    public string? OrderNr { get; set; }

    [Display("Is active")]
    public bool? IsActive { get; set; }
    
    [Display("Deal probability enabled")]
    public bool? DealProbability { get; set; }

}