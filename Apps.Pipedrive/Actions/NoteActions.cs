using Apps.Pipedrive.Api;
using Apps.Pipedrive.Models.Dto;
using Apps.Pipedrive.Models.Request.Note;
using Apps.Pipedrive.Models.Response.Note;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Utils.Parsers;

namespace Apps.Pipedrive.Actions;

[ActionList]
public class NoteActions
{
    [Action("List notes", Description = "Lists all notes")]
    public async Task<ListNotesResponse> ListNotes(
        IEnumerable<AuthenticationCredentialsProvider> creds,
        [ActionParameter] ListNotesRequest input)
    {
        var client = new PipedriveApiClient(creds);

        var response = await client.Paginate((lim, offset) =>
            client.Note.GetAll(new()
            {
                UserId = LongParser.Parse(input.UserId, nameof(input.UserId)),
                DealId = LongParser.Parse(input.DealId, nameof(input.DealId)),
                PersonId = LongParser.Parse(input.PersonId, nameof(input.PersonId)),
                OrgId = LongParser.Parse(input.OrgId, nameof(input.OrgId)),
                StartDate = input.StartDate,
                EndDate = input.EndDate,
                PageSize = lim,
                StartPage = offset
            }));

        var notes = response.Select(x => new NoteDto(x)).ToArray();
        return new(notes);
    }
    
    [Action("Get note", Description = "Get specific note")]
    public async Task<NoteDto> GetNote(
        IEnumerable<AuthenticationCredentialsProvider> creds,
        [ActionParameter] NoteRequest input)
    {
        var client = new PipedriveApiClient(creds);
        
        var response = await client.Note.Get(long.Parse(input.NoteId));
        return new(response);
    }
    
    [Action("Add note", Description = "Create a new note")]
    public async Task<NoteDto> AddNote(
        IEnumerable<AuthenticationCredentialsProvider> creds,
        [ActionParameter] AddNoteRequest input)
    {
        var client = new PipedriveApiClient(creds);
        
        var response = await client.Note.Create(new(input.Content)
        {
            DealId = LongParser.Parse(input.DealId, nameof(input.DealId)),
            OrgId = LongParser.Parse(input.OrgId, nameof(input.OrgId)),
            PersonId = LongParser.Parse(input.PersonId, nameof(input.PersonId)),
            PinnedToDealFlag = input.PinnedToDeal ?? false,
            PinnedToPersonFlag = input.PinnedToPerson ?? false,
            PinnedToOrganizationFlag = input.PinnedToOrganization ?? false,
        });
        return new(response);
    }
    
    [Action("Update note", Description = "Update specific note")]
    public async Task<NoteDto> UpdateNote(
        IEnumerable<AuthenticationCredentialsProvider> creds,
        [ActionParameter] NoteRequest note,
        [ActionParameter] UpdateNoteRequest input)
    {
        var client = new PipedriveApiClient(creds);
        
        var response = await client.Note.Edit(long.Parse(note.NoteId),new()
        {
            Content = input.Content,
            DealId = LongParser.Parse(input.DealId, nameof(input.DealId)),
            OrgId = LongParser.Parse(input.OrgId, nameof(input.OrgId)),
            PersonId = LongParser.Parse(input.PersonId, nameof(input.PersonId)),
            PinnedToDealFlag = input.PinnedToDeal ?? false,
            PinnedToPersonFlag = input.PinnedToPerson ?? false,
            PinnedToOrganizationFlag = input.PinnedToOrganization ?? false,
        });
        return new(response);
    }
    
    [Action("Delete note", Description = "Delete specific note")]
    public Task DeleteNote(
        IEnumerable<AuthenticationCredentialsProvider> creds,
        [ActionParameter] NoteRequest note)
    {
        var client = new PipedriveApiClient(creds);
        return client.Note.Delete(long.Parse(note.NoteId));
    }
}