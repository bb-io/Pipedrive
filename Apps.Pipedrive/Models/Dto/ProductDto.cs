using Apps.Pipedrive.Webhooks.Payload;
using Blackbird.Applications.Sdk.Common;
using Pipedrive;

namespace Apps.Pipedrive.Models.Dto;

public class ProductDto
{
    [Display("ID")] public string Id { get; set; }

    public string Name { get; set; }

    public string Code { get; set; }

    public string Description { get; set; }

    public string Unit { get; set; }

    public decimal Tax { get; set; }

    public string Category { get; set; }

    [Display("Add time")] public DateTime? AddTime { get; set; }

    [Display("Is private")] public bool IsPrivate { get; set; }

    [Display("Owner ID")] public string OwnerId { get; set; }
    public IEnumerable<PriceDto>? Prices { get; set; }

    public ProductDto(Product product)
    {
        Id = product.Id.ToString();
        Name = product.Name;
        Code = product.Code;
        Description = product.Description;
        Unit = product.Unit;
        Tax = product.Tax;
        Category = product.Category;
        AddTime = product.AddTime;
        IsPrivate = product.VisibleTo == Visibility.@private;
        OwnerId = product.Owner.Id.ToString();
        Prices = product.Prices?.Select(x => new PriceDto(x));
    }
    
    public ProductDto(ProductPayload product)
    {
        Id = product.Id.ToString();
        Name = product.Name;
        Code = product.Code;
        Description = product.Description;
        Unit = product.Unit;
        Tax = product.Tax;
        Category = product.Category;
        AddTime = product.AddTime;
        IsPrivate = product.VisibleTo == Visibility.@private;
        OwnerId = product.Owner.ToString();
        Prices = product.Prices?.Select(x => new PriceDto(x));
    }
}