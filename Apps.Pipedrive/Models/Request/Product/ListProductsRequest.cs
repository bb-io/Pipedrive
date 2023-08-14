using Apps.Pipedrive.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Pipedrive.Models.Request.Product;

public class ListProductsRequest
{
    [Display("User")]
    [DataSource(typeof(UserDataHandler))]
    public string? UserId { get; set; }
}