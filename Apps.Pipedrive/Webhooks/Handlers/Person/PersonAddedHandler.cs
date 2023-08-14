using Apps.Pipedrive.Webhooks.Handlers.Base;
using Pipedrive.Models.Common.Webhooks;

namespace Apps.Pipedrive.Webhooks.Handlers.Person;

public class PersonAddedHandler : WebhookHandler
{
    protected override EventAction EventAction => EventAction.Added;
    protected override EventObject EventObject => EventObject.Person;
}