using Newtonsoft.Json;
using Pipedrive;

namespace Apps.Pipedrive.Webhooks.Payload;

public class ProductPayload : Product
{
    [JsonProperty("owner_id")]
    public new long Owner { get; set; }
}