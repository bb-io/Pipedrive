using Apps.Pipedrive.Api;
using Apps.Pipedrive.Models.Dto;
using Apps.Pipedrive.Models.Request.Stage;
using Apps.Pipedrive.Models.Response.Stage;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Utils.Parsers;

namespace Apps.Pipedrive.Actions;

[ActionList]
public class StageActions
{
    [Action("List stages", Description = "Lists all stages")]
    public async Task<ListStagesResponse> ListStages(
        IEnumerable<AuthenticationCredentialsProvider> creds)
    {
        var client = new PipedriveApiClient(creds);

        var response = await client.Stage.GetAll();

        var stages = response.Select(x => new StageDto(x)).ToArray();
        return new(stages);
    }
    
    [Action("Get stage", Description = "Get details of a specific stage")]
    public async Task<StageDto> GetStage(
        IEnumerable<AuthenticationCredentialsProvider> creds,
        [ActionParameter] StageRequest stage)
    {
        var client = new PipedriveApiClient(creds);

        var response = await client.Stage.Get(long.Parse(stage.StageId));
        return new(response);
    }
    
    [Action("Add stage", Description = "Add a new stage")]
    public async Task<StageDto> AddStage(
        IEnumerable<AuthenticationCredentialsProvider> creds,
        [ActionParameter] AddStageRequest input)
    {
        var client = new PipedriveApiClient(creds);

        var response = await client.Stage.Create(new(input.Name, long.Parse(input.PipelineId))
        {
            RottenDays = input.RottenDays,
            RottenFlag = input.Rotten ?? default,
            DealProbability = input.DealProbability ?? default
        });
        return new(response);
    }
    
    [Action("Update stage", Description = "Update specific stage")]
    public async Task<StageDto> UpdateStage(
        IEnumerable<AuthenticationCredentialsProvider> creds,
        [ActionParameter] StageRequest stage,
        [ActionParameter] UpdateStageRequest  input)
    {
        var client = new PipedriveApiClient(creds);

        var response = await client.Stage.Edit(long.Parse(stage.StageId), new()
        {
            Name = input.Name,
            PipelineId = LongParser.Parse(input.PipelineId, nameof(input.PipelineId)) ?? default,
            RottenDays = input.RottenDays,
            RottenFlag = input.Rotten ?? default,
            DealProbability = input.DealProbability ?? default
        });
        return new(response);
    }
    
    [Action("Delete stage", Description = "Delete specific stage")]
    public Task DeleteStage(
        IEnumerable<AuthenticationCredentialsProvider> creds,
        [ActionParameter] StageRequest stage)
    {
        var client = new PipedriveApiClient(creds);
        return client.Stage.Delete(long.Parse(stage.StageId));
    }
}