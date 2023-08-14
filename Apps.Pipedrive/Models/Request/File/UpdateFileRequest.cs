namespace Apps.Pipedrive.Models.Request.File;

public class UpdateFileRequest : FileRequest
{
    public string? Name { get; set; }
    public string? Description { get; set; }
}