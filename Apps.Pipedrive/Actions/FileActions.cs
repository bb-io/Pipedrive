using Apps.Pipedrive.Api;
using Apps.Pipedrive.Models.Dto;
using Apps.Pipedrive.Models.Request.File;
using Apps.Pipedrive.Models.Response.File;
using Apps.Pipedrive.RestSharp;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Utils.Extensions.Files;
using Blackbird.Applications.Sdk.Utils.Parsers;
using Blackbird.Applications.SDK.Extensions.FileManagement.Interfaces;
using Pipedrive;
using RestSharp;

namespace Apps.Pipedrive.Actions;

[ActionList]
public class FileActions
{
    private readonly IFileManagementClient _fileManagementClient;

    public FileActions(IFileManagementClient fileManagementClient)
    {
        _fileManagementClient = fileManagementClient;
    }

    [Action("List files", Description = "Lists all files")]
    public async Task<ListFilesResponse> ListFiles(IEnumerable<AuthenticationCredentialsProvider> creds)
    {
        var client = new PipedriveApiClient(creds);

        var response = await client.Paginate((lim, offset) =>
            client.File.GetAll(new()
            {
                PageSize = lim,
                StartPage = offset
            }));

        var files = response.Select(x => new FileDto(x)).ToArray();
        return new(files);
    }

    [Action("Get file", Description = "Get specific file info")]
    public async Task<FileDto> GetFile(
        IEnumerable<AuthenticationCredentialsProvider> creds,
        [ActionParameter] FileRequest file)
    {
        var client = new PipedriveApiClient(creds);
        var response = await client.File.Get(long.Parse(file.FileId));

        return new(response);
    }

    [Action("Download file", Description = "Download file's content")]
    public async Task<FileContentResponse> DownloadFile(
        IEnumerable<AuthenticationCredentialsProvider> creds,
        [ActionParameter] FileRequest file)
    {
        var client = new PipedriveRestClient(creds);

        var endpoint = $"/v1/files/{file.FileId}/download";
        var request = new PipedriveRestRequest(endpoint, Method.Get, creds);

        var response = await client.ExecuteWithErrorHandling(request);
        var filename = response.ContentHeaders.First(h => h.Name == "Content-Disposition").Value.ToString().Split('"')[1];

        using var stream = new MemoryStream(response.RawBytes);
        var fileResponse = await _fileManagementClient.UploadAsync(stream, response.ContentType, filename);
        return new(fileResponse);
    }

    [Action("Add file", Description = "Upload a new file")]
    public async Task<FileDto> AddFile(
        IEnumerable<AuthenticationCredentialsProvider> creds,
        [ActionParameter] AddFileRequest input)
    {
        var client = new PipedriveApiClient(creds);

        var fileBytes = _fileManagementClient.DownloadAsync(input.File).Result.GetByteData().Result;
        var request = new NewFile(new(input.File.Name, fileBytes, input.File.ContentType))
        {
            DealId = LongParser.Parse(input.DealId, nameof(input.DealId)),
            PersonId = LongParser.Parse(input.PersonId, nameof(input.PersonId)),
            OrgId = LongParser.Parse(input.OrgId, nameof(input.OrgId)),
            ProductId = LongParser.Parse(input.ProductId, nameof(input.ProductId)),
            ActivityId = LongParser.Parse(input.ActivityId, nameof(input.ActivityId)),
            NoteId = LongParser.Parse(input.NoteId, nameof(input.NoteId)),
        };

        var response = await client.File.Create(request);
        return new(response);
    }

    [Action("Update file", Description = "Update details of a specific file")]
    public async Task<FileDto> UpdateFile(
        IEnumerable<AuthenticationCredentialsProvider> creds,
        [ActionParameter] UpdateFileRequest input)
    {
        var client = new PipedriveApiClient(creds);

        var request = new FileUpdate
        {
            Name = input.Name,
            Description = input.Description,
        };

        var response = await client.File.Edit(long.Parse(input.FileId), request);
        return new(response);
    }

    [Action("Delete file", Description = "Delete specific file")]
    public Task DeleteFile(
        IEnumerable<AuthenticationCredentialsProvider> creds,
        [ActionParameter] FileRequest file)
    {
        var client = new PipedriveApiClient(creds);

        return client.File.Delete(long.Parse(file.FileId));
    }
}