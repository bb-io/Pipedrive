
using Apps.Pipedrive.Actions;
using Apps.Pipedrive.Models.Request.Activity;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Connections;
using RestSharp;

namespace Apps.Pipedrive.Connections
{
    public class ConnectionValidator : IConnectionValidator
    {
        public async ValueTask<ConnectionValidationResponse> ValidateConnection(
       IEnumerable<AuthenticationCredentialsProvider> authProviders, CancellationToken cancellationToken)
        {
            var actions = new ActivityActions();
            try
            {
                await actions.ListActivities(authProviders, new ListActivitiesRequest { });
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
}
