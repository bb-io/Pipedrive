using Apps.Pipedrive.Webhooks.Handlers.Base;
using Pipedrive.Models.Common.Webhooks;

namespace Apps.Pipedrive.Webhooks.Handlers.Stage;

public class StageMergedHandler : WebhookHandler
{
    protected override EventAction EventAction => EventAction.Merged;
    protected override EventObject EventObject => EventObject.Stage;
}