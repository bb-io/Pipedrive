using Apps.Pipedrive.Api;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Webhooks;
using Pipedrive;
using Pipedrive.Models.Common.Webhooks;

namespace Apps.Pipedrive.Webhooks.Handlers.Base;

public abstract class WebhookHandler : IWebhookEventHandler
{
    protected abstract EventAction EventAction { get; }
    protected abstract EventObject EventObject { get; }

    public Task SubscribeAsync(IEnumerable<AuthenticationCredentialsProvider> creds, Dictionary<string, string> values)
    {
        var client = new PipedriveApiClient(creds);

        var request = new NewWebhook(values["payloadUrl"], EventAction, EventObject);
        return client.Webhook.Create(request);
    }

    public async Task UnsubscribeAsync(IEnumerable<AuthenticationCredentialsProvider> creds,
        Dictionary<string, string> values)
    {
        var client = new PipedriveApiClient(creds);

        var allWebhooks = await client.Webhook.GetAll();
        var webhookToDelete = allWebhooks
            .FirstOrDefault(x => x.SubscriptionUrl == values["payloadUrl"]);

        if (webhookToDelete is null)
            return;

        await client.Webhook.Delete(webhookToDelete.Id);
    }
}