using Blackbird.Applications.Sdk.Common;
using Pipedrive;

namespace Apps.Pipedrive.Models.Dto;

public class UserDto
{
    [Display("ID")] public string Id { get; set; }
    public string Name { get; set; }
    [Display("Company ID")] public string CompanyId { get; set; }
    public string Locale { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    [Display("Created at")] public DateTime CreatedAt { get; set; }
    [Display("Role ID")] public string RoleId { get; set; }
    
    [Display("Is active")] public bool IsActive { get; set; }

    public UserDto(User user)
    {
        Id = user.Id.ToString();
        Name = user.Name;
        CompanyId = user.CompanyId;
        Locale = user.Locale;
        Email = user.Email;
        Phone = user.Phone;
        CreatedAt = user.Created;
        RoleId = user.RoleId.ToString();
        IsActive = user.ActiveFlag;
    }
}