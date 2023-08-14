namespace Apps.Pipedrive.Models.Request.Note;

public class UpdateNoteRequest : AddNoteRequest
{
    public new string? Content { get; set; }
}