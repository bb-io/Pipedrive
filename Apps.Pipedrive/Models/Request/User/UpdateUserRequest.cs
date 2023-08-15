using Blackbird.Applications.Sdk.Common;

namespace Apps.Pipedrive.Models.Request.User;

public class UpdateUserRequest
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    
    [Display("Is active")]
    public bool? IsActive { get; set; }
}