using Apps.Pipedrive.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Pipedrive.Models.Request.User;

public class UserRequest
{
    [Display("User")]
    [DataSource(typeof(UserDataHandler))]
    public string UserId { get; set; }
}