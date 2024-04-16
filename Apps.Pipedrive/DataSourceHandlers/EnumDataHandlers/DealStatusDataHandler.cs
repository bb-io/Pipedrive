using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.Pipedrive.DataSourceHandlers.EnumDataHandlers;

public class DealStatusDataHandler : IStaticDataSourceHandler
{
    public Dictionary<string, string> GetData() => new()
    {
        { "open", "Open" },
        { "won", "Won" },
        { "lost", "Lost" },
        { "deleted", "Deleted" },
    };
}