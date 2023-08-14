using Apps.Pipedrive.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Pipedrive.Models.Request.Product;

public class ProductRequest
{
    [Display("Product")]
    [DataSource(typeof(ProductDataHandler))]
    public string ProductId { get; set; }   
}