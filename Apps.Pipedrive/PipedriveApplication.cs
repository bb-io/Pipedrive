using Blackbird.Applications.Sdk.Common;

namespace Apps.Pipedrive;

public class PipedriveApplication : IApplication
{
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