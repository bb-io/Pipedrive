using Apps.Pipedrive.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Pipedrive.Models.Request.Product;

public class UpdateProductRequest
{
    public string? Name { get; set; }
    public decimal? Price { get; set; }

    [DataSource(typeof(CurrencyDataHandler))]
    public string? Currency { get; set; }

    public string? Code { get; set; }

    public string? Unit { get; set; }

    public decimal? Tax { get; set; }

    [Display("Is active")] public bool? IsActive { get; set; }
    [Display("Is private")] public bool? IsPrivate { get; set; }

    [Display("Owner")]
    [DataSource(typeof(UserDataHandler))]
    public string? OwnerId { get; set; }
}