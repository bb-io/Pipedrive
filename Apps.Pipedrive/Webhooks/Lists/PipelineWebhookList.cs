using Apps.Pipedrive.Models.Dto;
using Apps.Pipedrive.Webhooks.Handlers.Pipeline;
using Apps.Pipedrive.Webhooks.Lists.Base;
using Blackbird.Applications.Sdk.Common.Webhooks;
using Pipedrive;

namespace Apps.Pipedrive.Webhooks.Lists;

[WebhookList]
public class PipelineWebhookList : WebhookList
{
    [Webhook("On pipeline added", typeof(PipelineAddedHandler), Description = "On new pipeline added")]
    public Task<WebhookResponse<PipelineDto>> OnPipelineAdded(WebhookRequest webhookRequest)
        => HandleWebhookRequest<Pipeline, PipelineDto>(webhookRequest, x => new(x));

    [Webhook("On pipeline deleted", typeof(PipelineDeletedHandler), Description = "On specific pipeline deleted")]
    public Task<WebhookResponse<PipelineDto>> OnPipelineDeleted(WebhookRequest webhookRequest)
        => HandleWebhookRequest<Pipeline, PipelineDto>(webhookRequest, x => new(x));

    [Webhook("On pipeline merged", typeof(PipelineMergedHandler), Description = "On specific pipeline merged")]
    public Task<WebhookResponse<PipelineDto>> OnPipelineMerged(WebhookRequest webhookRequest)
        => HandleWebhookRequest<Pipeline, PipelineDto>(webhookRequest, x => new(x));

    [Webhook("On pipeline updated", typeof(PipelineUpdatedHandler), Description = "On specific pipeline updated")]
    public Task<WebhookResponse<PipelineDto>> OnPipelineUpdated(WebhookRequest webhookRequest)
        => HandleWebhookRequest<Pipeline, PipelineDto>(webhookRequest, x => new(x));
}