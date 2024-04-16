using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Metadata;

namespace Apps.Pipedrive;

public class PipedriveApplication : IApplication, ICategoryProvider
{
    public IEnumerable<ApplicationCategory> Categories
    {
        get => [ApplicationCategory.Crm];
        set { }
    }
    
    public T GetInstance<T>()
    {
        throw new NotImplementedException();
    }

    public string Name
    {
        get => "Pipedrive";
        set { }
    }
}