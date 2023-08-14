using Blackbird.Applications.Sdk.Common;
using Pipedrive;

namespace Apps.Pipedrive.Models.Dto;

public class PersonDto
{
    [Display("ID")]
    public string Id { get; set; }
    
    [Display("First name")]
    public string FirstName { get; set; }
    
    [Display("Last name")]
    public string LastName { get; set; }
    public string Name { get; set; }
    
    [Display("Company ID")]
    public string? CompanyId { get; set; }
    public IEnumerable<string>? Emails { get; set; }
    public IEnumerable<string>? Phones { get; set; }
    
    [Display("Add time")]
    public DateTime? AddTime { get; set; }

    [Display("Organization ID")]
    public string? OrgId { get; set; }

    [Display("Owner ID")]
    public string? OwnerId { get; set; }

    [Display("Is private")]
    public bool IsPrivate { get; set; }

    public PersonDto(WebhookPerson person)
    {
        Id = person.Id.ToString();
        FirstName = person.FirstName;
        LastName = person.LastName;
        Name = person.Name;
        CompanyId = person.CompanyId.ToString();
        Emails = person.Email.Select(x => x.Value);
        Phones = person.Phone.Select(x => x.Value);
        AddTime = person.AddTime;
        OrgId = person.OrgId.ToString();
        OwnerId = person.OwnerId.ToString();
        IsPrivate = person.VisibleTo == Visibility.@private;
    }

    public PersonDto(Person person)
    {
        Id = person.Id.ToString();
        FirstName = person.FirstName;
        LastName = person.LastName;
        Name = person.Name;
        CompanyId = person.CompanyId.ToString();
        Emails = person.Email.Select(x => x.Value);
        Phones = person.Phone.Select(x => x.Value);
        AddTime = person.AddTime;
        OrgId = person.OrgId.ToString();
        OwnerId = person.OwnerId.ToString();
        IsPrivate = person.VisibleTo == Visibility.@private;
    }
}