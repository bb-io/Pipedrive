using System.Net;
using Apps.Pipedrive.Api;
using Apps.Pipedrive.Models.Dto;
using Apps.Pipedrive.Webhooks.Handlers.Organization;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Pipedrive.Webhooks.Lists;

[WebhookList]
public class OrganizationWebhookList : BaseInvocable
{
    public OrganizationWebhookList(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    [Webhook("On organization added", typeof(OrganizationAddedHandler), Description = "On new organization added")]
    public Task<WebhookResponse<OrganizationDto>> OnOrganizationAdded(WebhookRequest webhookRequest)
        => HandleWebhookRequest(webhookRequest);

    [Webhook("On organization deleted", typeof(OrganizationDeletedHandler), Description = "On specific organization deleted")]
    public Task<WebhookResponse<OrganizationDto>> OnOrganizationDeleted(WebhookRequest webhookRequest)
        => HandleWebhookRequest(webhookRequest);

    [Webhook("On organization merged", typeof(OrganizationMergedHandler), Description = "On specific organization merged")]
    public Task<WebhookResponse<OrganizationDto>> OnOrganizationMerged(WebhookRequest webhookRequest)
        => HandleWebhookRequest(webhookRequest);

    [Webhook("On organization updated", typeof(OrganizationUpdatedHandler), Description = "On specific organization updated")]
    public Task<WebhookResponse<OrganizationDto>> OnOrganizationUpdated(WebhookRequest webhookRequest)
        => HandleWebhookRequest(webhookRequest);

    private Task<WebhookResponse<OrganizationDto>> HandleWebhookRequest(WebhookRequest webhookRequest)
    {
        var client = new PipedriveApiClient(InvocationContext.AuthenticationCredentialsProviders);
        var payload = client.Webhook.ParseWebhookOrganizationResponse(webhookRequest.Body.ToString());

        return Task.FromResult(new WebhookResponse<OrganizationDto>
        {
            HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK),
            Result = new OrganizationDto(payload.Current)
        });
    }
}