using Apps.Pipedrive.Models.Dto;
using Apps.Pipedrive.Webhooks.Handlers.Note;
using Apps.Pipedrive.Webhooks.Lists.Base;
using Blackbird.Applications.Sdk.Common.Webhooks;
using Pipedrive;

namespace Apps.Pipedrive.Webhooks.Lists;

[WebhookList]
public class NoteWebhookList : WebhookList
{
    [Webhook("On note added", typeof(NoteAddedHandler), Description = "On new note added")]
    public Task<WebhookResponse<NoteDto>> OnNoteAdded(WebhookRequest webhookRequest)
        => HandleWebhookRequest<Note, NoteDto>(webhookRequest, x => new(x));

    [Webhook("On note deleted", typeof(NoteDeletedHandler), Description = "On specific note deleted")]
    public Task<WebhookResponse<NoteDto>> OnNoteDeleted(WebhookRequest webhookRequest)
        => HandleWebhookRequest<Note, NoteDto>(webhookRequest, x => new(x));
    
    [Webhook("On note updated", typeof(NoteUpdatedHandler), Description = "On specific note updated")]
    public Task<WebhookResponse<NoteDto>> OnNoteUpdated(WebhookRequest webhookRequest)
        => HandleWebhookRequest<Note, NoteDto>(webhookRequest, x => new(x));
}