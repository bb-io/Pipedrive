using Apps.Pipedrive.Models.Dto;
using Apps.Pipedrive.Webhooks.Handlers.User;
using Apps.Pipedrive.Webhooks.Lists.Base;
using Blackbird.Applications.Sdk.Common.Webhooks;
using Pipedrive;

namespace Apps.Pipedrive.Webhooks.Lists;

[WebhookList]
public class UserWebhookList : WebhookList
{
    [Webhook("On user added", typeof(UserAddedHandler), Description = "On new user added")]
    public Task<WebhookResponse<UserDto>> OnUserAdded(WebhookRequest webhookRequest)
        => HandleWebhookRequest<User, UserDto>(webhookRequest, x => new(x));

    [Webhook("On user deleted", typeof(UserDeletedHandler), Description = "On specific user deleted")]
    public Task<WebhookResponse<UserDto>> OnUserDeleted(WebhookRequest webhookRequest)
        => HandleWebhookRequest<User, UserDto>(webhookRequest, x => new(x));

    [Webhook("On user merged", typeof(UserMergedHandler), Description = "On specific user merged")]
    public Task<WebhookResponse<UserDto>> OnUserMerged(WebhookRequest webhookRequest)
        => HandleWebhookRequest<User, UserDto>(webhookRequest, x => new(x));

    [Webhook("On user updated", typeof(UserUpdatedHandler), Description = "On specific user updated")]
    public Task<WebhookResponse<UserDto>> OnUserUpdated(WebhookRequest webhookRequest)
        => HandleWebhookRequest<User, UserDto>(webhookRequest, x => new(x));
}