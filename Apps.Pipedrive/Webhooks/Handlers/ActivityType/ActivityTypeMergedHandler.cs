using Apps.Pipedrive.Webhooks.Handlers.Base;
using Pipedrive.Models.Common.Webhooks;

namespace Apps.Pipedrive.Webhooks.Handlers.ActivityType;

public class ActivityTypeMergedHandler : WebhookHandler
{
    protected override EventAction EventAction => EventAction.Merged;
    protected override EventObject EventObject => EventObject.ActivityType;
}