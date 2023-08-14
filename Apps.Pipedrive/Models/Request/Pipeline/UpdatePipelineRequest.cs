namespace Apps.Pipedrive.Models.Request.Pipeline;

public class UpdatePipelineRequest : AddPipelineRequest
{
    public new string? Name { get; set; }
}