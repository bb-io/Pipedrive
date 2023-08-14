using System.Net;
using Apps.Pipedrive.Api;
using Apps.Pipedrive.Models.Dto;
using Apps.Pipedrive.Webhooks.Handlers.Person;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Pipedrive.Webhooks.Lists;

[WebhookList]
public class PersonWebhookList : BaseInvocable
{
    public PersonWebhookList(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    [Webhook("On person added", typeof(PersonAddedHandler), Description = "On new person added")]
    public Task<WebhookResponse<PersonDto>> OnPersonAdded(WebhookRequest webhookRequest)
        => HandleWebhookRequest(webhookRequest);

    [Webhook("On person deleted", typeof(PersonDeletedHandler), Description = "On specific person deleted")]
    public Task<WebhookResponse<PersonDto>> OnPersonDeleted(WebhookRequest webhookRequest)
        => HandleWebhookRequest(webhookRequest);

    [Webhook("On person merged", typeof(PersonMergedHandler), Description = "On specific person merged")]
    public Task<WebhookResponse<PersonDto>> OnPersonMerged(WebhookRequest webhookRequest)
        => HandleWebhookRequest(webhookRequest);

    [Webhook("On person updated", typeof(PersonUpdatedHandler), Description = "On specific person updated")]
    public Task<WebhookResponse<PersonDto>> OnPersonUpdated(WebhookRequest webhookRequest)
        => HandleWebhookRequest(webhookRequest);

    private Task<WebhookResponse<PersonDto>> HandleWebhookRequest(WebhookRequest webhookRequest)
    {
        var client = new PipedriveApiClient(InvocationContext.AuthenticationCredentialsProviders);
        var payload = client.Webhook.ParseWebhookPersonResponse(webhookRequest.Body.ToString());

        return Task.FromResult(new WebhookResponse<PersonDto>
        {
            HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK),
            Result = new PersonDto(payload.Current)
        });
    }
}