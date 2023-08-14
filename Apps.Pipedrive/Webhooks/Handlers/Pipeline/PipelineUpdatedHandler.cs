using Apps.Pipedrive.Webhooks.Handlers.Base;
using Pipedrive.Models.Common.Webhooks;

namespace Apps.Pipedrive.Webhooks.Handlers.Pipeline;

public class PipelineUpdatedHandler : WebhookHandler
{
    protected override EventAction EventAction => EventAction.Updated;
    protected override EventObject EventObject => EventObject.Pipeline;
}