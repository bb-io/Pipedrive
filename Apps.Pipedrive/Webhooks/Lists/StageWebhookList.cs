using Apps.Pipedrive.Models.Dto;
using Apps.Pipedrive.Webhooks.Handlers.Stage;
using Apps.Pipedrive.Webhooks.Lists.Base;
using Blackbird.Applications.Sdk.Common.Webhooks;
using Pipedrive;

namespace Apps.Pipedrive.Webhooks.Lists;

[WebhookList]
public class StageWebhookList : WebhookList
{
    [Webhook("On stage added", typeof(StageAddedHandler), Description = "On new stage added")]
    public Task<WebhookResponse<StageDto>> OnStageAdded(WebhookRequest webhookRequest)
        => HandleWebhookRequest<Stage, StageDto>(webhookRequest, x => new(x));

    [Webhook("On stage deleted", typeof(StageDeletedHandler), Description = "On specific stage deleted")]
    public Task<WebhookResponse<StageDto>> OnStageDeleted(WebhookRequest webhookRequest)
        => HandleWebhookRequest<Stage, StageDto>(webhookRequest, x => new(x));

    [Webhook("On stage merged", typeof(StageMergedHandler), Description = "On specific stage merged")]
    public Task<WebhookResponse<StageDto>> OnStageMerged(WebhookRequest webhookRequest)
        => HandleWebhookRequest<Stage, StageDto>(webhookRequest, x => new(x));

    [Webhook("On stage updated", typeof(StageUpdatedHandler), Description = "On specific stage updated")]
    public Task<WebhookResponse<StageDto>> OnStageUpdated(WebhookRequest webhookRequest)
        => HandleWebhookRequest<Stage, StageDto>(webhookRequest, x => new(x));
}