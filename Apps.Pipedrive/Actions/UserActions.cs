using Apps.Pipedrive.Api;
using Apps.Pipedrive.Models.Dto;
using Apps.Pipedrive.Models.Request.User;
using Apps.Pipedrive.Models.Response.User;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Authentication;
using Pipedrive;

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
    
    [Action("Get user", Description = "Get details of a specific user")]
    public async Task<UserDto> GetUser(
        IEnumerable<AuthenticationCredentialsProvider> creds,
        [ActionParameter] UserRequest user)
    {
        var client = new PipedriveApiClient(creds);

        var response = await client.User.Get(long.Parse(user.UserId));
        return new(response);
    }
    
    [Action("Add user", Description = "Add a new user")]
    public async Task<UserDto> AddUser(
        IEnumerable<AuthenticationCredentialsProvider> creds,
        [ActionParameter] AddUserRequest input)
    {
        var client = new PipedriveApiClient(creds);

        var request = new NewUser(input.Name, input.Email, input.IsActive ?? true);
        var response = await client.User.Create(request);
        
        return new(response);
    }    
    
    [Action("Deactivate user", Description = "Deactivate specific user")]
    public async Task<UserDto> DeactivateUser(
        IEnumerable<AuthenticationCredentialsProvider> creds,
        [ActionParameter] UserRequest input)
    {
        var client = new PipedriveApiClient(creds);

        var response = await client.User.Edit(long.Parse(input.UserId), new()
        {
            ActiveFlag = false
        });
        
        return new(response);
    }
    
    [Action("Activate user", Description = "Activate specific user")]
    public async Task<UserDto> ActivateteUser(
        IEnumerable<AuthenticationCredentialsProvider> creds,
        [ActionParameter] UserRequest input)
    {
        var client = new PipedriveApiClient(creds);

        var response = await client.User.Edit(long.Parse(input.UserId), new()
        {
            ActiveFlag = true
        });
        
        return new(response);
    }
}