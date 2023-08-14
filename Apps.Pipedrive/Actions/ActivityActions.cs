using Apps.Pipedrive.Api;
using Apps.Pipedrive.Models.Dto;
using Apps.Pipedrive.Models.Request.Activity;
using Apps.Pipedrive.Models.Request.User;
using Apps.Pipedrive.Models.Response.Activity;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Utils.Parsers;
using Pipedrive;

namespace Apps.Pipedrive.Actions;

[ActionList]
public class ActivityActions
{
    [Action("List activities", Description = "List all activities")]
    public async Task<ListActivitiesResponse> ListActivities(IEnumerable<AuthenticationCredentialsProvider> creds,
        [ActionParameter] ListActivitiesRequest input)
    {
        var client = new PipedriveApiClient(creds);

        var response = await client.Paginate((limit, offset)
            => client.Activity.GetAll(new()
            {
                Type = input.Type,
                StartDate = input.StartDate,
                EndDate = input.EndDate,
                StartPage = offset,
                PageSize = limit,
                Done = input.IsActivityDone switch
                {
                    true => ActivityDone.Done,
                    false => ActivityDone.Undone,
                    _ => null
                }
            }));

        var activities = response.Select(x => new ActivityDto(x)).ToArray();
        return new(activities);
    }

    [Action("List user activities", Description = "List all activities assigned to a particular user")]
    public async Task<ListActivitiesResponse> ListUserActivities(IEnumerable<AuthenticationCredentialsProvider> creds,
        [ActionParameter] UserRequest user,
        [ActionParameter] ListActivitiesRequest input)
    {
        var client = new PipedriveApiClient(creds);

        var intUserId = LongParser.Parse(user.UserId, nameof(user.UserId))!.Value;
        var response = await client.Activity.GetAllForUserId(intUserId, new()
        {
            Type = input.Type,
            StartDate = input.StartDate,
            EndDate = input.EndDate,
            Done = input.IsActivityDone switch
            {
                true => ActivityDone.Done,
                false => ActivityDone.Undone,
                _ => null
            }
        });

        var activities = response.Select(x => new ActivityDto(x)).ToArray();
        return new(activities);
    }

    [Action("Get activity", Description = "Get details of a specific activity")]
    public async Task<ActivityDto> GetActivity(IEnumerable<AuthenticationCredentialsProvider> creds,
        [ActionParameter] ActivityRequest input)
    {
        var client = new PipedriveApiClient(creds);
        var response = await client.Activity.Get(long.Parse(input.ActivityId));

        return new(response);
    }

    [Action("Create activity", Description = "Add a new activity")]
    public async Task<ActivityDto> CreateActivity(IEnumerable<AuthenticationCredentialsProvider> creds,
        [ActionParameter] ManageActivityRequest input)
    {
        var client = new PipedriveApiClient(creds);
        var response = await client.Activity.Create(new(input.Subject, input.Type)
        {
            Done = input.IsDone is true ? ActivityDone.Done : ActivityDone.Undone,
            DueDate = input.DueDate,
            DueTime = input.DueTime,
            Duration = input.Duration,
            UserId = LongParser.Parse(input.UserId, nameof(input.UserId)),
            DealId = LongParser.Parse(input.DealId, nameof(input.DealId)),
            PersonId = LongParser.Parse(input.PersonId, nameof(input.PersonId)),
            Participants = input.Participants?.Select(x => new Participant
            {
                PersonId = LongParser.Parse(x, nameof(input.PersonId)) ?? throw new("One participant IDs is null")
            }).ToList(),
            OrgId = LongParser.Parse(input.OrganizationId, nameof(input.OrganizationId)),
            Note = input.Note,
            Location = input.Location,
            PublicDescription = input.PublicDescription,
            BusyFlag = input.BusyFlag
        });

        return new(response);
    }

    [Action("Update activity", Description = "Update specific activity")]
    public async Task<ActivityDto> UpdateActivity(IEnumerable<AuthenticationCredentialsProvider> creds,
        [ActionParameter] ActivityRequest activity,
        [ActionParameter] ManageActivityRequest input)
    {
        var client = new PipedriveApiClient(creds);
        var response = await client.Activity.Edit(long.Parse(activity.ActivityId),
            new()
            {
                Done = input.IsDone is true ? ActivityDone.Done : ActivityDone.Undone,
                DueDate = input.DueDate,
                DueTime = input.DueTime,
                Duration = input.Duration,
                UserId = LongParser.Parse(input.UserId, nameof(input.UserId)),
                DealId = LongParser.Parse(input.DealId, nameof(input.DealId)),
                PersonId = LongParser.Parse(input.PersonId, nameof(input.PersonId)),
                Participants = input.Participants.Select(x => new Participant
                {
                    PersonId = LongParser.Parse(x, nameof(input.PersonId)) ?? throw new("One participant IDs is null")
                }).ToList(),
                OrgId = LongParser.Parse(input.OrganizationId, nameof(input.OrganizationId)),
                Note = input.Note,
                Location = input.Location,
                PublicDescription = input.PublicDescription,
                BusyFlag = input.BusyFlag,
                Subject = input.Subject,
                Type = input.Type
            });

        return new(response);
    }

    [Action("Delete activity", Description = "Delete specific activity")]
    public Task DeleteActivity(IEnumerable<AuthenticationCredentialsProvider> creds,
        [ActionParameter] ActivityRequest activity)
    {
        var client = new PipedriveApiClient(creds);
        return client.Activity.Delete(long.Parse(activity.ActivityId));
    }
}