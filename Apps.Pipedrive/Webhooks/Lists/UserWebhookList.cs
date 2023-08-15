using Apps.Pipedrive.Models.Dto;
using Apps.Pipedrive.Models.Response.User;
using Apps.Pipedrive.Webhooks.Handlers.User;
using Apps.Pipedrive.Webhooks.Lists.Base;
using Apps.Pipedrive.Webhooks.Payload;
using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Pipedrive.Webhooks.Lists;

[WebhookList]
public class UserWebhookList : WebhookList
{
    [Webhook("On user added", typeof(UserAddedHandler), Description = "On new user added")]
    public Task<WebhookResponse<ListUsersResponse>> OnUserAdded(WebhookRequest webhookRequest)
        => HandleWebhookRequest<List<UserPayload>, ListUsersResponse>(webhookRequest,
            x => new(x.Select(x => new UserDto(x)).ToArray()));

    [Webhook("On user updated", typeof(UserUpdatedHandler), Description = "On specific user updated")]
    public Task<WebhookResponse<ListUsersResponse>> OnUserUpdated(WebhookRequest webhookRequest)
        => HandleWebhookRequest<List<UserPayload>, ListUsersResponse>(webhookRequest,
            x => new(x.Select(x => new UserDto(x)).ToArray()));
}