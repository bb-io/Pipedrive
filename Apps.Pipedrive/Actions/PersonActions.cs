using Apps.Pipedrive.Api;
using Apps.Pipedrive.Models.Dto;
using Apps.Pipedrive.Models.Request.Person;
using Apps.Pipedrive.Models.Response.Person;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Utils.Parsers;
using Pipedrive;

namespace Apps.Pipedrive.Actions;

[ActionList]
public class PersonActions
{
    [Action("List people", Description = "Lists all people")]
    public async Task<ListPeopleResponse> ListPeople(
        IEnumerable<AuthenticationCredentialsProvider> creds)
    {
        var client = new PipedriveApiClient(creds);

        var response = await client.Paginate((lim, offset) =>
            client.Person.GetAll(new()
            {
                StartPage = offset,
                PageSize = lim
            }));

        var people = response.Select(x => new PersonDto(x)).ToArray();
        return new(people);
    }
    
    [Action("Get person", Description = "Get details of a specific person")]
    public async Task<PersonDto> GetPerson(
        IEnumerable<AuthenticationCredentialsProvider> creds,
        [ActionParameter] PersonRequest person)
    {
        var client = new PipedriveApiClient(creds);

        var response = await client.Person.Get(long.Parse(person.PersonId));
        return new(response);
    }
    
    [Action("Add person", Description = "Add a new person")]
    public async Task<PersonDto> AddPerson(
        IEnumerable<AuthenticationCredentialsProvider> creds,
        [ActionParameter] AddPersonRequest input)
    {
        var client = new PipedriveApiClient(creds);

        var response = await client.Person.Create(new(input.Name)
        {
            OwnerId = LongParser.Parse(input.OwnerId, nameof(input.OwnerId)) ?? default,
            OrgId = LongParser.Parse(input.OrgId, nameof(input.OrgId)) ?? default,
            VisibleTo = input.IsPrivate is true ? Visibility.@private : Visibility.shared,
            Email = new List<Email>
            {
                new()
                {
                    Value = input.Email
                }
            },
            Phone = new List<Phone>
            {
                new()
                {
                    Value = input.Phone
                }
            }
        });
        return new(response);
    }
    
    [Action("Update person", Description = "Update specific person")]
    public async Task<PersonDto> UpdatePerson(
        IEnumerable<AuthenticationCredentialsProvider> creds,
        [ActionParameter] PersonRequest person,
        [ActionParameter] UpdatePersonRequest input)
    {
        var client = new PipedriveApiClient(creds);

        var response = await client.Person.Edit(long.Parse(person.PersonId), new()
        {
            Name = input.Name,
            OwnerId = LongParser.Parse(input.OwnerId, nameof(input.OwnerId)) ?? default,
            OrgId = LongParser.Parse(input.OrgId, nameof(input.OrgId)) ?? default,
            VisibleTo = input.IsPrivate is true ? Visibility.@private : Visibility.shared,
            Email = new List<Email>
            {
                new()
                {
                    Value = input.Email
                }
            },
            Phone = new List<Phone>
            {
                new()
                {
                    Value = input.Phone
                }
            }
        });
        return new(response);
    }
    
    [Action("Delete person", Description = "Delete specific person")]
    public Task DeletePerson(
        IEnumerable<AuthenticationCredentialsProvider> creds,
        [ActionParameter] PersonRequest person)
    {
        var client = new PipedriveApiClient(creds);
        return client.Person.Delete(long.Parse(person.PersonId));
    }
}