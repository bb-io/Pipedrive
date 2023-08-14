using Apps.Pipedrive.Webhooks.Handlers.Base;
using Pipedrive.Models.Common.Webhooks;

namespace Apps.Pipedrive.Webhooks.Handlers.User;

public class UserMergedHandler : WebhookHandler
{
    protected override EventAction EventAction => EventAction.Merged;
    protected override EventObject EventObject => EventObject.User;
}