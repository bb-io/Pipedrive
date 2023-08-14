using System.Net;
using Blackbird.Applications.Sdk.Common.Webhooks;
using Newtonsoft.Json;
using Pipedrive.Webhooks;

namespace Apps.Pipedrive.Webhooks.Lists.Base;

public abstract class WebhookList
{
    protected Task<Blackbird.Applications.Sdk.Common.Webhooks.WebhookResponse<TV>> HandleWebhookRequest<T, TV>(
        WebhookRequest webhookRequest, Func<T, TV> dtoConstructor) where TV : class
    {
        var payload = JsonConvert.DeserializeObject<IWebhookResponse<T>>(webhookRequest.Body.ToString());

        if (payload == null)
            throw new Exception("No serializable payload was found in incoming request.");

        return Task.FromResult(new Blackbird.Applications.Sdk.Common.Webhooks.WebhookResponse<TV>
        {
            HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK),
            Result = dtoConstructor(payload.Current)
        });
    }
}