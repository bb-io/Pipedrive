using Blackbird.Applications.Sdk.Utils.Sdk.DataSourceHandlers;

namespace Apps.Pipedrive.DataSourceHandlers.EnumDataHandlers;

public class ActivityTypeDataHandler : EnumDataHandler
{
    protected override Dictionary<string, string> EnumValues => new()
    {
        { "call", "Call" },
        { "meeting", "Meeting" },
        { "task", "Task" },
        { "deadline", "Deadline" },
        { "email", "Email" },
        { "lunch", "Lunch" },
    };
}