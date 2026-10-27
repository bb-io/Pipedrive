using Apps.Pipedrive.Api;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Connections;

namespace Apps.Pipedrive.Connections;

public class ConnectionValidator : IConnectionValidator
{
    public async ValueTask<ConnectionValidationResponse> ValidateConnection(
        IEnumerable<AuthenticationCredentialsProvider> authProviders, 
        CancellationToken cancellationToken)
    {
        try
        {
            var client = new PipedriveApiClient(authProviders);
            await client.User.Me();
            
            return new ConnectionValidationResponse
            {
                IsValid = true,
                Message = "Success"
            };
        }
        catch (Exception ex)
        {
            return new ConnectionValidationResponse
            {
                IsValid = false,
                Message = ex.Message
            };
        }
    }
}