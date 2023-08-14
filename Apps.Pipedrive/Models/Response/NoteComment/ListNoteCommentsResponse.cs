using Apps.Pipedrive.Models.Dto;

namespace Apps.Pipedrive.Models.Response.NoteComment;

public record ListNoteCommentsResponse(NoteCommentDto[] Comments);