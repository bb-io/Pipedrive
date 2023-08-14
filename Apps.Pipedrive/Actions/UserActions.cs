using Apps.Pipedrive.Api;
using Apps.Pipedrive.Models.Dto;
using Apps.Pipedrive.Models.Response.User;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Authentication;

namespace Apps.Pipedrive.Actions;

[ActionList]
public class UserActions
{
    [Action("List users", Description = "Lists all users")]
    public async Task<ListUsersResponse> ListUsers(
        IEnumerable<AuthenticationCredentialsProvider> creds)
    {
        var client = new PipedriveApiClient(creds);

        var response = await client.User.GetAll();

        var users = response.Select(x => new UserDto(x)).ToArray();
        return new(users);
    }
}