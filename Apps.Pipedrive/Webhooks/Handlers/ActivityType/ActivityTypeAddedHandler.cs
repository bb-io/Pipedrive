using Apps.Pipedrive.Webhooks.Handlers.Base;
using Pipedrive.Models.Common.Webhooks;

namespace Apps.Pipedrive.Webhooks.Handlers.ActivityType;

public class ActivityTypeAddedHandler : WebhookHandler
{
    protected override EventAction EventAction => EventAction.Added;
    protected override EventObject EventObject => EventObject.ActivityType;
}