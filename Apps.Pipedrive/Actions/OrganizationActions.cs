using Apps.Pipedrive.Api;
using Apps.Pipedrive.Models.Dto;
using Apps.Pipedrive.Models.Request.Organization;
using Apps.Pipedrive.Models.Response.Organization;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Utils.Parsers;
using Pipedrive;

namespace Apps.Pipedrive.Actions;

[ActionList]
public class OrganizationActions
{
    [Action("List organizations", Description = "Lists all organizations")]
    public async Task<ListOrganizationsResponse> ListOrganizations(
        IEnumerable<AuthenticationCredentialsProvider> creds)
    {
        var client = new PipedriveApiClient(creds);

        var response = await client.Paginate((lim, offset) =>
            client.Organization.GetAll(new()
            {
                PageSize = lim,
                StartPage = offset
            }));

        var organizations = response.Select(x => new OrganizationDto(x)).ToArray();
        return new(organizations);
    }
    
    [Action("Get organization", Description = "Get specific organization")]
    public async Task<OrganizationDto> GetOrganization(
        IEnumerable<AuthenticationCredentialsProvider> creds,
        [ActionParameter] OrganizationRequest organization)
    {
        var client = new PipedriveApiClient(creds);

        var response = await client.Organization.Get(long.Parse(organization.OrgId));
        return new(response);
    }
    
    [Action("Add organization", Description = "Add a new organization")]
    public async Task<OrganizationDto> AddOrganization(
        IEnumerable<AuthenticationCredentialsProvider> creds,
        [ActionParameter] AddOrgRequest input)
    {
        var client = new PipedriveApiClient(creds);

        var response = await client.Organization.Create(new(input.Name)
        {
            VisibleTo = input.IsPrivate is true ? Visibility.@private : Visibility.shared,
            OwnerId = LongParser.Parse(input.OwnerId, nameof(input.OwnerId)) ?? default
        });
        return new(response);
    }
    
    [Action("Update organization", Description = "Update specific organization")]
    public async Task<OrganizationDto> UpdateOrganization(
        IEnumerable<AuthenticationCredentialsProvider> creds,
        [ActionParameter] OrganizationRequest org,
        [ActionParameter] UpdateOrgRequest input)
    {
        var client = new PipedriveApiClient(creds);

        var response = await client.Organization.Edit(long.Parse(org.OrgId), new()
        {
            Name = input.Name,
            VisibleTo = input.IsPrivate is true ? Visibility.@private : Visibility.shared,
            OwnerId = LongParser.Parse(input.OwnerId, nameof(input.OwnerId)) ?? default
        });
        return new(response);
    }
    
    [Action("Delete organization", Description = "Delete specific organization")]
    public Task DeleteOrganization(
        IEnumerable<AuthenticationCredentialsProvider> creds,
        [ActionParameter] OrganizationRequest org)
    {
        var client = new PipedriveApiClient(creds);
        return client.Organization.Delete(long.Parse(org.OrgId));
    }
}