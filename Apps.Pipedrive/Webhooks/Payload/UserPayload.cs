using Newtonsoft.Json;
using Pipedrive;

namespace Apps.Pipedrive.Webhooks.Payload;

public class UserPayload : User
{
    [JsonProperty("lang")]
    public new string Lang { get; set; }
}