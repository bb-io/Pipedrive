using Apps.Pipedrive.Api;
using Apps.Pipedrive.Models.Dto;
using Apps.Pipedrive.Models.Request.Product;
using Apps.Pipedrive.Models.Response.Product;
using Apps.Pipedrive.RestSharp;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Utils.Extensions.Http;
using Blackbird.Applications.Sdk.Utils.Parsers;
using Newtonsoft.Json;
using Pipedrive;
using RestSharp;

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
        var client = new PipedriveRestClient(creds);

        var payload = new NewProduct(input.Name)
        {
            Code = input.Code,
            Unit = input.Unit,
            Tax = input.Tax ?? default,
            VisibleTo = input.IsPrivate is true ? Visibility.@private : Visibility.shared,
            ActiveFlag = input.IsActive ?? true,
            OwnerId = LongParser.Parse(input.OwnerId, nameof(input.OwnerId)) ?? default,
            Prices = new()
            {
                new()
                {
                    Price = input.Price,
                    Currency = input.Currency,
                }
            }
        };
        var request = new PipedriveRestRequest("v1/products", Method.Post, creds)
            .WithJsonBody(payload, new()
            {
                DefaultValueHandling = DefaultValueHandling.Ignore
            });
        var response = await client.ExecuteWithErrorHandling<JsonResponse<Product>>(request);
        
        return new(response.Data);
    }
    
    [Action("Update product", Description = "Update specific product")]
    public async Task<ProductDto> UpdateProduct(
        IEnumerable<AuthenticationCredentialsProvider> creds,
        [ActionParameter] ProductRequest product,
        [ActionParameter] UpdateProductRequest input)
    {
        if (input.Currency == null ^ input.Price == null)
            throw new("Price and Currency must be both specified or null");
        
        var client = new PipedriveRestClient(creds);

        var payload = new ProductUpdate()
        {
            Name = input.Name,
            Code = input.Code,
            Unit = input.Unit,
            Tax = input.Tax ?? default,
            VisibleTo = input.IsPrivate is true ? Visibility.@private : Visibility.shared,
            ActiveFlag = input.IsActive ?? true,
            OwnerId = LongParser.Parse(input.OwnerId, nameof(input.OwnerId)) ?? default,
            Prices = new()
        };
        
        if (input.Price is not null)
            payload.Prices.Add(new()
            {
                Price = input.Price!.Value,
                Currency = input.Currency
            });
        
        var request = new PipedriveRestRequest($"v1/products/{product.ProductId}", Method.Put, creds)
            .WithJsonBody(payload, new()
            {
                DefaultValueHandling = DefaultValueHandling.Ignore
            });
        var response = await client.ExecuteWithErrorHandling<JsonResponse<Product>>(request);
        
        return new(response.Data);
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