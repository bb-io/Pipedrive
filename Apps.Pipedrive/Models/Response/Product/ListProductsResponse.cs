using Apps.Pipedrive.Models.Dto;

namespace Apps.Pipedrive.Models.Response.Product;

public record ListProductsResponse(ProductDto[] Products);