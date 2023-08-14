using Apps.Pipedrive.Constants;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Utils.Extensions.Sdk;
using Blackbird.Applications.Sdk.Utils.Extensions.String;
using Blackbird.Applications.Sdk.Utils.RestSharp;
using Pipedrive;
using RestSharp;
using NotImplementedException = System.NotImplementedException;

namespace Apps.Pipedrive.RestSharp;

public class PipedriveRestClient : BlackBirdRestClient
{
    public PipedriveRestClient(IEnumerable<AuthenticationCredentialsProvider> creds) :
        base(GetClientOptions(creds))
    {
    }

    protected override Exception ConfigureErrorException(RestResponse response)
    {
        throw new NotImplementedException();
    }

    private static RestClientOptions GetClientOptions(IEnumerable<AuthenticationCredentialsProvider> creds)
    {
        return new()
        {
            BaseUrl = new(creds.Get(CredsNames.Url).Value)
        };
    }

    public async Task<List<T>> Paginate<T>(PipedriveRestRequest request)
    {
        var start = 0;
        var limit = 100;

        var result = new List<T>();
        JsonResponse<T[]> response;
        do
        {
            request.Resource = request.Resource.WithQuery(new()
            {
                { "start", start.ToString() },
                { "limit", limit.ToString() }
            });

            response = await ExecuteWithErrorHandling<JsonResponse<T[]>>(request);
            result.AddRange(response.Data);

            start += limit;
        } while (response.AdditionalData.Pagination.MoreItemsInCollection);

        return result;
    }
}