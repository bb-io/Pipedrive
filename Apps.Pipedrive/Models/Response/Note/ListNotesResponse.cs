using Apps.Pipedrive.Models.Dto;

namespace Apps.Pipedrive.Models.Response.Note;

public record ListNotesResponse(NoteDto[] Notes);