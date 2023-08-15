using Apps.Pipedrive.Models.Dto;
using Apps.Pipedrive.Models.Request.Note;
using Apps.Pipedrive.Models.Request.NoteComments;
using Apps.Pipedrive.Models.Response.NoteComment;
using Apps.Pipedrive.RestSharp;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Utils.Extensions.Http;
using Newtonsoft.Json.Serialization;
using Pipedrive;
using RestSharp;

namespace Apps.Pipedrive.Actions;

[ActionList]
public class NoteCommentActions
{
    [Action("List note comments", Description = "Lists all note comments")]
    public async Task<ListNoteCommentsResponse> ListNoteComments(
        IEnumerable<AuthenticationCredentialsProvider> creds,
        [ActionParameter] NoteRequest note)
    {
        var client = new PipedriveRestClient(creds);

        var endpoint = $"/v1/notes/{note.NoteId}/comments";
        var request = new PipedriveRestRequest(endpoint, Method.Get, creds);

        var response = await client.Paginate<NoteCommentResponse>(request);
        var comments = response.Select(x => new NoteCommentDto(x)).ToArray();

        return new(comments);
    }

    [Action("Get note comment", Description = "Get specific note comment")]
    public async Task<NoteCommentDto> GetNoteComment(
        IEnumerable<AuthenticationCredentialsProvider> creds,
        [ActionParameter] NoteRequest note,
        [ActionParameter] [Display("Comment UUID")]
        string commentId)
    {
        var client = new PipedriveRestClient(creds);

        var endpoint = $"/v1/notes/{note.NoteId}/comments/{commentId}";
        var request = new PipedriveRestRequest(endpoint, Method.Get, creds);

        var response = await client.ExecuteWithErrorHandling<JsonResponse<NoteCommentResponse>>(request);
        response.Data.Uuid = commentId;
        
        return new(response.Data);
    }

    [Action("Add note comment", Description = "Create a new note comment")]
    public async Task<NoteCommentDto> AddNoteComment(
        IEnumerable<AuthenticationCredentialsProvider> creds,
        [ActionParameter] NoteRequest note,
        [ActionParameter] AddNoteCommentRequest input)
    {
        var client = new PipedriveRestClient(creds);

        var endpoint = $"/v1/notes/{note.NoteId}/comments";
        var request = new PipedriveRestRequest(endpoint, Method.Post, creds)
            .WithJsonBody(input, new()
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new SnakeCaseNamingStrategy()
                }
            });

        var response = await client.ExecuteWithErrorHandling<JsonResponse<NoteCommentResponse>>(request);
        return new(response.Data);
    }

    [Action("Update note comment", Description = "Update specific note comment")]
    public async Task<NoteCommentDto> UpdateNoteComment(
        IEnumerable<AuthenticationCredentialsProvider> creds,
        [ActionParameter] NoteRequest note,
        [ActionParameter] [Display("Comment UUID")]
        string commentId,
        [ActionParameter] AddNoteCommentRequest input)
    {
        var client = new PipedriveRestClient(creds);

        var endpoint = $"/v1/notes/{note.NoteId}/comments/{commentId}";
        var request = new PipedriveRestRequest(endpoint, Method.Put, creds)
            .WithJsonBody(input, new()
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new SnakeCaseNamingStrategy()
                }
            });

        var response = await client.ExecuteWithErrorHandling<JsonResponse<NoteCommentResponse>>(request);
        return new(response.Data);
    }

    [Action("Delete note comment", Description = "Delete specific note comment")]
    public Task DeleteNoteComment(
        IEnumerable<AuthenticationCredentialsProvider> creds,
        [ActionParameter] NoteRequest note,
        [ActionParameter] [Display("Comment UUID")]
        string commentId)
    {
        var client = new PipedriveRestClient(creds);

        var endpoint = $"/v1/notes/{note.NoteId}/comments/{commentId}";
        var request = new PipedriveRestRequest(endpoint, Method.Delete, creds);

        return client.ExecuteWithErrorHandling(request);
    }
}