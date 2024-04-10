using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.Pipedrive.DataSourceHandlers.EnumDataHandlers;

public class ActivityTypeDataHandler : IStaticDataSourceHandler
{
    public Dictionary<string, string> GetData() => new()
    {
        { "call", "Call" },
        { "meeting", "Meeting" },
        { "task", "Task" },
        { "deadline", "Deadline" },
        { "email", "Email" },
        { "lunch", "Lunch" },
    };
}