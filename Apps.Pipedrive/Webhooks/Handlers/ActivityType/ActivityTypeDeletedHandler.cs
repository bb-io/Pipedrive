using Apps.Pipedrive.Webhooks.Handlers.Base;
using Pipedrive.Models.Common.Webhooks;

namespace Apps.Pipedrive.Webhooks.Handlers.ActivityType;

public class ActivityTypeDeletedHandler : WebhookHandler
{
    protected override EventAction EventAction => EventAction.Deleted;
    protected override EventObject EventObject => EventObject.ActivityType;
}