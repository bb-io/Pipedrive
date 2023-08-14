using System.Net;
using Apps.Pipedrive.Api;
using Apps.Pipedrive.Models.Dto;
using Apps.Pipedrive.Webhooks.Handlers.Activity;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Pipedrive.Webhooks.Lists;

[WebhookList]
public class ActivityWebhookList : BaseInvocable
{
    public ActivityWebhookList(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    [Webhook("On activity added", typeof(ActivityAddedHandler), Description = "On new activity added")]
    public Task<WebhookResponse<ActivityDto>> OnActivityAdded(WebhookRequest webhookRequest)
        => HandleWebhookRequest(webhookRequest);

    [Webhook("On activity deleted", typeof(ActivityDeletedHandler), Description = "On specific activity deleted")]
    public Task<WebhookResponse<ActivityDto>> OnActivityDeleted(WebhookRequest webhookRequest)
        => HandleWebhookRequest(webhookRequest);

    [Webhook("On activity merged", typeof(ActivityMergedHandler), Description = "On specific activity merged")]
    public Task<WebhookResponse<ActivityDto>> OnActivityMerged(WebhookRequest webhookRequest)
        => HandleWebhookRequest(webhookRequest);

    [Webhook("On activity updated", typeof(ActivityUpdatedHandler), Description = "On specific activity updated")]
    public Task<WebhookResponse<ActivityDto>> OnActivityUpdated(WebhookRequest webhookRequest)
        => HandleWebhookRequest(webhookRequest);

    private Task<WebhookResponse<ActivityDto>> HandleWebhookRequest(WebhookRequest webhookRequest)
    {
        var client = new PipedriveApiClient(InvocationContext.AuthenticationCredentialsProviders);
        var payload = client.Webhook.ParseWebhookActivityResponse(webhookRequest.Body.ToString());

        return Task.FromResult(new WebhookResponse<ActivityDto>
        {
            HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK),
            Result = new ActivityDto(payload.Current)
        });
    }
}