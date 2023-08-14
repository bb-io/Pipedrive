using Apps.Pipedrive.Models.Dto;
using Apps.Pipedrive.Webhooks.Handlers.Product;
using Apps.Pipedrive.Webhooks.Lists.Base;
using Blackbird.Applications.Sdk.Common.Webhooks;
using Pipedrive;

namespace Apps.Pipedrive.Webhooks.Lists;

[WebhookList]
public class ProductWebhookList : WebhookList
{
    [Webhook("On product added", typeof(ProductAddedHandler), Description = "On new product added")]
    public Task<WebhookResponse<ProductDto>> OnProductAdded(WebhookRequest webhookRequest)
        => HandleWebhookRequest<Product, ProductDto>(webhookRequest, x => new(x));

    [Webhook("On product deleted", typeof(ProductDeletedHandler), Description = "On specific product deleted")]
    public Task<WebhookResponse<ProductDto>> OnProductDeleted(WebhookRequest webhookRequest)
        => HandleWebhookRequest<Product, ProductDto>(webhookRequest, x => new(x));

    [Webhook("On product merged", typeof(ProductMergedHandler), Description = "On specific product merged")]
    public Task<WebhookResponse<ProductDto>> OnProductMerged(WebhookRequest webhookRequest)
        => HandleWebhookRequest<Product, ProductDto>(webhookRequest, x => new(x));

    [Webhook("On product updated", typeof(ProductUpdatedHandler), Description = "On specific product updated")]
    public Task<WebhookResponse<ProductDto>> OnProductUpdated(WebhookRequest webhookRequest)
        => HandleWebhookRequest<Product, ProductDto>(webhookRequest, x => new(x));
}