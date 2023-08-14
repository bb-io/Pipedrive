using Apps.Pipedrive.Api;
using Apps.Pipedrive.Models.Dto;
using Apps.Pipedrive.Models.Request.Pipeline;
using Apps.Pipedrive.Models.Response.Pipeline;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Utils.Parsers;

namespace Apps.Pipedrive.Actions;

[ActionList]
public class PipelineActions
{
    [Action("List pipelines", Description = "Lists all pipelines")]
    public async Task<ListPipelinesResponse> ListPipelines(
        IEnumerable<AuthenticationCredentialsProvider> creds)
    {
        var client = new PipedriveApiClient(creds);
        var response = await client.Pipeline.GetAll();

        var pipelines = response.Select(x => new PipelineDto(x)).ToArray();
        return new(pipelines);
    }
    
    [Action("Get pipeline", Description = "Get specific pipeline")]
    public async Task<PipelineDto> GetPipeline(
        IEnumerable<AuthenticationCredentialsProvider> creds,
        [ActionParameter] PipelineRequest pipeline)
    {
        var client = new PipedriveApiClient(creds);
        var response = await client.Pipeline.Get(long.Parse(pipeline.PipelineId));

        return new(response);
    }
    
    [Action("Add pipeline", Description = "Add a new pipeline")]
    public async Task<PipelineDto> AddPipeline(
        IEnumerable<AuthenticationCredentialsProvider> creds,
        [ActionParameter] AddPipelineRequest input)
    {
        var client = new PipedriveApiClient(creds);
        var response = await client.Pipeline.Create(new(input.Name)
        {
            OrderNr = LongParser.Parse(input.OrderNr, nameof(input.OrderNr)) ?? default,
            DealProbability = input.DealProbability ?? default,
            Active = input.IsActive ?? true
        });

        return new(response);
    }
    
    [Action("Update pipeline", Description = "Update specific pipeline")]
    public async Task<PipelineDto> UpdatePipeline(
        IEnumerable<AuthenticationCredentialsProvider> creds,
        [ActionParameter] PipelineRequest pipeline,
        [ActionParameter] UpdatePipelineRequest input)
    {
        var client = new PipedriveApiClient(creds);
        var response = await client.Pipeline.Edit(long.Parse(pipeline.PipelineId), new()
        {
            Name = input.Name,
            OrderNr = LongParser.Parse(input.OrderNr, nameof(input.OrderNr)) ?? default,
            DealProbability = input.DealProbability ?? default,
            Active = input.IsActive ?? true
        });

        return new(response);
    }
    
    [Action("Delete pipeline", Description = "Delete specific pipeline")]
    public Task DeletePipeline(
        IEnumerable<AuthenticationCredentialsProvider> creds,
        [ActionParameter] PipelineRequest pipeline)
    {
        var client = new PipedriveApiClient(creds);
        return client.Pipeline.Delete(long.Parse(pipeline.PipelineId));
    }
}