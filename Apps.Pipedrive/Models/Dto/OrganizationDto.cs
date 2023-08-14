using Blackbird.Applications.Sdk.Common;
using Pipedrive;

namespace Apps.Pipedrive.Models.Dto;

public class OrganizationDto
{
    [Display("ID")]
    public string Id { get; set; }

    public string Name { get; set; }

    [Display("Company ID")]
    public string CompanyId { get; set; }

    [Display("Owner name")]
    public string OwnerName { get; set; }
    
    [Display("Add time")]
    public DateTime? AddTime { get; set; }

    [Display("Is private")]
    public bool IsPrivate { get; set; }
    
    public OrganizationDto(WebhookOrganization org)
    {
        Id = org.Id.ToString();
        Name = org.Name;
        CompanyId = org.CompanyId.ToString();
        OwnerName = org.OwnerName;
        AddTime = org.AddTime;
        IsPrivate = org.VisibleTo == Visibility.@private;
    }

    public OrganizationDto(Organization org)
    {
        Id = org.Id.ToString();
        Name = org.Name;
        CompanyId = org.CompanyId.ToString();
        OwnerName = org.OwnerName;
        AddTime = org.AddTime;
        IsPrivate = org.VisibleTo == Visibility.@private;
    }
}