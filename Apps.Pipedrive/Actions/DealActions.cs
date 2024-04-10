using Apps.Pipedrive.Api;
using Apps.Pipedrive.Constants;
using Apps.Pipedrive.Models.Dto;
using Apps.Pipedrive.Models.Request.Deal;
using Apps.Pipedrive.Models.Response.Activity;
using Apps.Pipedrive.Models.Response.Deal;
using Apps.Pipedrive.Models.Response.File;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Utils.Parsers;
using Pipedrive;

namespace Apps.Pipedrive.Actions;

[ActionList]
public class DealActions
{
    [Action("List deals", Description = "List all deals")]
    public async Task<ListDealsResponse> ListDeals(IEnumerable<AuthenticationCredentialsProvider> creds,
        [ActionParameter] ListDealsRequest input)
    {
        var client = new PipedriveApiClient(creds);

        var response = await client.Paginate((limit, offset) =>
            client.Deal.GetAll(new()
            {
                StageId = LongParser.Parse(input.StageId, nameof(input.StageId)),
                Status = EnumParser.Parse<DealStatus>(input.Status, nameof(input.Status)),
                StartPage = offset,
                PageSize = limit
            }));

        var deals = response.Select(x => new DealDto(x)).ToArray();
        return new(deals);
    }

    [Action("List activities associated with a deal",
        Description = "Lists all activities associated with a specific deal")]
    public async Task<ListActivitiesResponse> ListDealActivities(IEnumerable<AuthenticationCredentialsProvider> creds,
        [ActionParameter] DealRequest input)
    {
        var client = new PipedriveApiClient(creds);

        var response = await client.Paginate((lim, offset) =>
            client.Deal.GetActivities(long.Parse(input.DealId), new()
            {
                PageSize = lim,
                StartPage = offset
            }));

        var activities = response.Select(x => new ActivityDto(x)).ToArray();
        return new(activities);
    }

    [Action("List files attached to a deal", Description = "Lists all files associated with a specific deal")]
    public async Task<ListFilesResponse> ListDealFiles(IEnumerable<AuthenticationCredentialsProvider> creds,
        [ActionParameter] DealRequest input)
    {
        var client = new PipedriveApiClient(creds);

        var response = await client.Paginate((lim, offset) =>
            client.Deal.GetFiles(long.Parse(input.DealId), new()
            {
                StartPage = offset,
                PageSize = lim
            }));
        var files = response.Select(x => new FileDto(x)).ToArray();
        return new(files);
    }

    [Action("Get deal", Description = "Get details of a specific deal")]
    public async Task<DealDto> GetDeal(IEnumerable<AuthenticationCredentialsProvider> creds,
        [ActionParameter] DealRequest deal)
    {
        var client = new PipedriveApiClient(creds);
        var response = await client.Deal.Get(long.Parse(deal.DealId));

        return new(response);
    }

    [Action("Create deal", Description = "Create a new deal")]
    public async Task<DealDto> CreateDeal(IEnumerable<AuthenticationCredentialsProvider> creds,
        [ActionParameter] ManageDealRequest input)
    {
        var client = new PipedriveApiClient(creds);
        var response = await client.Deal.Create(new(input.Title)
        {
            Currency = input.Currency,
            Value = input.Value,
            UserId = LongParser.Parse(input.UserId, nameof(input.UserId)),
            OrgId = LongParser.Parse(input.OrgId, nameof(input.OrgId)),
            PersonId = LongParser.Parse(input.PersonId, nameof(input.PersonId)),
            StageId = LongParser.Parse(input.StageId, nameof(input.StageId)),
            Status = EnumParser.Parse<DealStatus>(input.Status, nameof(input.Status)) ??
                     DealStatus.open,
            Probability = input.Probability ?? default,
            LostReason = input.LostReason,
            VisibleTo = input.IsPrivate is true ? Visibility.@private : Visibility.shared,
            AddTime = input.AddTime,
            CloseTime = input.CloseTime,
            LostTime = input.LostTime,
            FirstWonTime = input.FirstWonTime,
            WonTime = input.WonTime,
            ExpectedCloseDate = input.ExpectedCloseDate,
        });

        return new(response);
    }

    [Action("Update deal", Description = "Update specific deal")]
    public async Task<DealDto> UpdateDeal(IEnumerable<AuthenticationCredentialsProvider> creds,
        [ActionParameter] DealRequest deal,
        [ActionParameter] ManageDealRequest input)
    {
        var client = new PipedriveApiClient(creds);
        var response = await client.Deal.Edit(long.Parse(deal.DealId), new()
        {
            Title = input.Title,
            Currency = input.Currency,
            Value = input.Value,
            UserId = LongParser.Parse(input.UserId, nameof(input.UserId)),
            OrgId = LongParser.Parse(input.OrgId, nameof(input.OrgId)),
            PersonId = LongParser.Parse(input.PersonId, nameof(input.PersonId)),
            StageId = LongParser.Parse(input.StageId, nameof(input.StageId)),
            Status = EnumParser.Parse<DealStatus>(input.Status, nameof(input.Status)) ??
                     DealStatus.open,
            Probability = input.Probability ?? default,
            LostReason = input.LostReason,
            VisibleTo = input.IsPrivate is true ? Visibility.@private : Visibility.shared,
            AddTime = input.AddTime,
            CloseTime = input.CloseTime,
            LostTime = input.LostTime,
            FirstWonTime = input.FirstWonTime,
            WonTime = input.WonTime,
            ExpectedCloseDate = input.ExpectedCloseDate,
        });

        return new(response);
    }

    [Action("Delete deal", Description = "Delete specific")]
    public Task DeleteDeal(IEnumerable<AuthenticationCredentialsProvider> creds,
        [ActionParameter] DealRequest deal)
    {
        var client = new PipedriveApiClient(creds);
        return client.Deal.Delete(long.Parse(deal.DealId));
    }
}