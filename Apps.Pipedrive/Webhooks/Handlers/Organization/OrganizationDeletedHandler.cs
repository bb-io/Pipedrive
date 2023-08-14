﻿using Apps.Pipedrive.Webhooks.Handlers.Base;
using Pipedrive.Models.Common.Webhooks;

namespace Apps.Pipedrive.Webhooks.Handlers.Organization;

public class OrganizationDeletedHandler : WebhookHandler
{
    protected override EventAction EventAction => EventAction.Deleted;
    protected override EventObject EventObject => EventObject.Organization;
}