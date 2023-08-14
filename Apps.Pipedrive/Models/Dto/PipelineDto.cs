using Blackbird.Applications.Sdk.Common;
using Pipedrive;

namespace Apps.Pipedrive.Models.Dto;

public class PipelineDto
{
    [Display("ID")]
    public string Id { get; set; }

    public string Name { get; set; }

    [Display("URL title")]
    public string UrlTitle { get; set; }

    [Display("Order number")]
    public string OrderNr { get; set; }

    [Display("Add time")]
    public DateTime? AddTime { get; set; }

    [Display("Is active")]
    public bool IsActive { get; set; }

    [Display("Is selected")]
    public bool IsSelected { get; set; }
    
    [Display("Deal probability enabled")]
    public bool DealProbability { get; set; }
    
    public PipelineDto(Pipeline pipeline)
    {
        Id = pipeline.Id.ToString();
        Name = pipeline.Name;
        UrlTitle = pipeline.UrlTitle;
        OrderNr = pipeline.OrderNr.ToString();
        AddTime = pipeline.AddTime;
        IsActive = pipeline.Active;
        IsSelected = pipeline.Selected;
        DealProbability = pipeline.DealProbability;
    }
}