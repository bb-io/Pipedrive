using Apps.Pipedrive.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Pipedrive.Models.Request.Product;

public class UpdateProductRequest : AddProductRequest
{
    public new string? Name { get; set; }
    public new decimal? Price { get; set; }
    
    [DataSource(typeof(CurrencyDataHandler))]
    public new string? Currency { get; set; }
}