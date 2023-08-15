using Pipedrive;

namespace Apps.Pipedrive.Models.Dto;

public class PriceDto
{
    public string? Currency { get; set; }
    public decimal? Price { get; set; }

    public PriceDto(ProductPrice productPrice)
    {
        Price = productPrice.Price;
        Currency = productPrice.Currency;
    }
}