using Apps.Pipedrive.Models.Dto;
using Apps.Pipedrive.Webhooks.Handlers.ActivityType;
using Apps.Pipedrive.Webhooks.Lists.Base;
using Blackbird.Applications.Sdk.Common.Webhooks;
using Pipedrive;

namespace Apps.Pipedrive.Webhooks.Lists;

[WebhookList]
public class ActivityTypeTypeWebhookList : WebhookList
{
    [Webhook("On activity type added", typeof(ActivityTypeAddedHandler), Description = "On new activity type added")]
    public Task<WebhookResponse<ActivityTypeDto>> OnActivityTypeAdded(WebhookRequest webhookRequest)
        => HandleWebhookRequest<ActivityType, ActivityTypeDto>(webhookRequest, x => new(x));

    [Webhook("On activity type deleted", typeof(ActivityTypeDeletedHandler), Description = "On specific activity type deleted")]
    public Task<WebhookResponse<ActivityTypeDto>> OnActivityTypeDeleted(WebhookRequest webhookRequest)
        => HandleWebhookRequest<ActivityType, ActivityTypeDto>(webhookRequest, x => new(x));

    [Webhook("On activity type merged", typeof(ActivityTypeMergedHandler), Description = "On specific activity type merged")]
    public Task<WebhookResponse<ActivityTypeDto>> OnActivityTypeMerged(WebhookRequest webhookRequest)
        => HandleWebhookRequest<ActivityType, ActivityTypeDto>(webhookRequest, x => new(x));

    [Webhook("On activity type updated", typeof(ActivityTypeUpdatedHandler), Description = "On specific activity type updated")]
    public Task<WebhookResponse<ActivityTypeDto>> OnActivityTypeUpdated(WebhookRequest webhookRequest)
        => HandleWebhookRequest<ActivityType, ActivityTypeDto>(webhookRequest, x => new(x));
}