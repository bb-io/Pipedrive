using Apps.Pipedrive.Webhooks.Handlers.Base;
using Pipedrive.Models.Common.Webhooks;

namespace Apps.Pipedrive.Webhooks.Handlers.Note;

public class NoteMergedHandler : WebhookHandler
{
    protected override EventAction EventAction => EventAction.Merged;
    protected override EventObject EventObject => EventObject.Note;
}