using Blackbird.Applications.Sdk.Utils.Sdk.DataSourceHandlers;

namespace Apps.Pipedrive.DataSourceHandlers.EnumDataHandlers;

public class DealStatusDataHandler : EnumDataHandler
{
    protected override Dictionary<string, string> EnumValues => new()
    {
        { "open", "Open" },
        { "won", "Won" },
        { "lost", "Lost" },
        { "deleted", "Deleted" },
    };
}