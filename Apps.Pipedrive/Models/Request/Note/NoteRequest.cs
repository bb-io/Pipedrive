using Apps.Pipedrive.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Pipedrive.Models.Request.Note;

public class NoteRequest
{
    [Display("Note")] 
    [DataSource(typeof(NoteDataHandler))]
    public string NoteId { get; set; }
}