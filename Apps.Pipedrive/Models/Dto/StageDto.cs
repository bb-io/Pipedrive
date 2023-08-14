using Blackbird.Applications.Sdk.Common;
using Pipedrive;

namespace Apps.Pipedrive.Models.Dto;

public class StageDto
{
    [Display("ID")] public string Id { get; set; }

    public string Name { get; set; }

    [Display("Pipeline ID")] public string PipelineId { get; set; }

    [Display("Order number")] public string OrderNr { get; set; }

    [Display("Add time")] public DateTime? AddTime { get; set; }

    public StageDto(Stage stage)
    {
        Id = stage.Id.ToString();
        Name = stage.Name;
        PipelineId = stage.PipelineId.ToString();
        OrderNr = stage.OrderNr.ToString();
        AddTime = stage.AddTime;
    }
}