using Apps.Pipedrive.Constants;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Connections;

namespace Apps.Pipedrive.Connections;

public class ConnectionDefinition : IConnectionDefinition
{
    public IEnumerable<ConnectionPropertyGroup> ConnectionPropertyGroups => new List<ConnectionPropertyGroup>
    {
        new()
        {
            Name = "Developer API key",
            AuthenticationType = ConnectionAuthenticationType.Undefined,
            ConnectionUsage = ConnectionUsage.Actions,
            ConnectionProperties = new List<ConnectionProperty>
            {
                new(CredsNames.ApiToken)
                {
                    DisplayName = "API Token",
                    Description =
                        "You can obtain your API key from the API Settings https://[your organization].pipedrive.com/settings/api"
                },
                new(CredsNames.Url)
                {
                    DisplayName = "Pipedrive instance URL",
                    Description =
                        "Base URL of your Pipedrive sandbox workspace"
                }
            }
        }
    };

    public IEnumerable<AuthenticationCredentialsProvider> CreateAuthorizationCredentialsProviders(
        Dictionary<string, string> values)
    {
        var token = values.First(x => x.Key == CredsNames.ApiToken);
        var url = values.First(x => x.Key == CredsNames.Url);
        
        yield return new(AuthenticationCredentialsRequestLocation.None, token.Key, token.Value);
        yield return new(AuthenticationCredentialsRequestLocation.None, url.Key, url.Value);
    }
}