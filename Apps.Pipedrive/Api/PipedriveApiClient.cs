using Apps.Pipedrive.Constants;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Utils.Extensions.Sdk;
using Pipedrive;

namespace Apps.Pipedrive.Api;

public class PipedriveApiClient : PipedriveClient
{
    public PipedriveApiClient(IEnumerable<AuthenticationCredentialsProvider> creds)
        : base(new("Blackbird.io"), new(creds.Get(CredsNames.Url).Value))
    {
        var token = creds.Get(CredsNames.ApiToken)!;
        Credentials = new(token.Value, AuthenticationType.ApiToken);
    }

    public async Task<List<T>> Paginate<T>(Func<int, int, Task<IReadOnlyList<T>>> requestFunc)
    {
        var result = new List<T>();
        var limit = 100;
        var offset = 0;

        IReadOnlyList<T> response;
        do
        {
            response = await requestFunc(limit, offset);
            offset += limit;

            result.AddRange(response);
        } while (response.Any());

        return result;
    }
}