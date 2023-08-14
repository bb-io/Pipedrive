using Apps.Pipedrive.Api;
using Apps.Pipedrive.Models.Dto;
using Apps.Pipedrive.Models.Response.Stage;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Authentication;

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
}