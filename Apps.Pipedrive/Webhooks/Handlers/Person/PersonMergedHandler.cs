using Apps.Pipedrive.Webhooks.Handlers.Base;
using Pipedrive.Models.Common.Webhooks;

namespace Apps.Pipedrive.Webhooks.Handlers.Person;

public class PersonMergedHandler : WebhookHandler
{
    protected override EventAction EventAction => EventAction.Merged;
    protected override EventObject EventObject => EventObject.Person;
}