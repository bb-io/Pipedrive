using Apps.Pipedrive.Api;
using Apps.Pipedrive.Models.Dto;
using Apps.Pipedrive.Models.Request.Product;
using Apps.Pipedrive.Models.Response.Product;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Utils.Parsers;
using Pipedrive;

namespace Apps.Pipedrive.Actions;

[ActionList]
public class ProductActions
{
    [Action("List products", Description = "Lists all products")]
    public async Task<ListProductsResponse> ListProducts(
        IEnumerable<AuthenticationCredentialsProvider> creds,
        [ActionParameter] ListProductsRequest input)
    {
        var client = new PipedriveApiClient(creds);
        var response = await client.Paginate((lim, offset) =>
            client.Product.GetAll(new()
            {
                PageSize = lim,
                StartPage = offset,
                UserId = LongParser.Parse(input.UserId, nameof(input.UserId))
            }));

        var products = response.Select(x => new ProductDto(x)).ToArray();
        return new(products);
    }
    
    [Action("Get product", Description = "Get details of a specific product")]
    public async Task<ProductDto> GetProduct(
        IEnumerable<AuthenticationCredentialsProvider> creds,
        [ActionParameter] ProductRequest product)
    {
        var client = new PipedriveApiClient(creds);
        
        var response = await client.Product.Get(long.Parse(product.ProductId));
        return new(response);
    }
    
    [Action("Add product", Description = "Add a new product")]
    public async Task<ProductDto> AddProduct(
        IEnumerable<AuthenticationCredentialsProvider> creds,
        [ActionParameter] AddProductRequest input)
    {
        var client = new PipedriveApiClient(creds);
        
        var response = await client.Product.Create(new(input.Name)
        {
            Code = input.Code,
            Unit = input.Unit,
            Tax = input.Tax ?? default,
            VisibleTo = input.IsPrivate is true ? Visibility.@private : Visibility.shared,
            ActiveFlag = input.IsActive ?? true,
            OwnerId = LongParser.Parse(input.OwnerId, nameof(input.OwnerId)) ?? default
        });
        return new(response);
    }
    
    [Action("Update product", Description = "Update specific product")]
    public async Task<ProductDto> UpdateProduct(
        IEnumerable<AuthenticationCredentialsProvider> creds,
        [ActionParameter] ProductRequest product,
        [ActionParameter] UpdateProductRequest input)
    {
        var client = new PipedriveApiClient(creds);
        
        var response = await client.Product.Edit(long.Parse(product.ProductId),new()
        {
            Name = input.Name,
            Code = input.Code,
            Unit = input.Unit,
            Tax = input.Tax ?? default,
            VisibleTo = input.IsPrivate is true ? Visibility.@private : Visibility.shared,
            ActiveFlag = input.IsActive ?? true,
            OwnerId = LongParser.Parse(input.OwnerId, nameof(input.OwnerId)) ?? default
        });
        
        return new(response);
    }
    
    [Action("Delete product", Description = "Delete specific product")]
    public Task DeleteProduct(
        IEnumerable<AuthenticationCredentialsProvider> creds,
        [ActionParameter] ProductRequest product)
    {
        var client = new PipedriveApiClient(creds);
        return client.Product.Delete(long.Parse(product.ProductId));
    }
}