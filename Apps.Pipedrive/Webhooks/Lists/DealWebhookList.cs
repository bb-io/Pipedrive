using System.Net;
using Apps.Pipedrive.Api;
using Apps.Pipedrive.Models.Dto;
using Apps.Pipedrive.Webhooks.Handlers.Deal;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Pipedrive.Webhooks.Lists;

[WebhookList]
public class DealWebhookList : BaseInvocable
{
    public DealWebhookList(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    [Webhook("On deal added", typeof(DealAddedHandler), Description = "On new deal added")]
    public Task<WebhookResponse<DealDto>> OnDealAdded(WebhookRequest webhookRequest)
        => HandleWebhookRequest(webhookRequest);

    [Webhook("On deal deleted", typeof(DealDeletedHandler), Description = "On specific deal deleted")]
    public Task<WebhookResponse<DealDto>> OnDealDeleted(WebhookRequest webhookRequest)
        => HandleWebhookRequest(webhookRequest);

    [Webhook("On deal merged", typeof(DealMergedHandler), Description = "On specific deal merged")]
    public Task<WebhookResponse<DealDto>> OnDealMerged(WebhookRequest webhookRequest)
        => HandleWebhookRequest(webhookRequest);

    [Webhook("On deal updated", typeof(DealUpdatedHandler), Description = "On specific deal updated")]
    public Task<WebhookResponse<DealDto>> OnDealUpdated(WebhookRequest webhookRequest)
        => HandleWebhookRequest(webhookRequest);

    private Task<WebhookResponse<DealDto>> HandleWebhookRequest(WebhookRequest webhookRequest)
    {
        var client = new PipedriveApiClient(InvocationContext.AuthenticationCredentialsProviders);
        var payload = client.Webhook.ParseWebhookDealResponse(webhookRequest.Body.ToString());

        return Task.FromResult(new WebhookResponse<DealDto>
        {
            HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK),
            Result = new DealDto(payload.Current)
        });
    }
}