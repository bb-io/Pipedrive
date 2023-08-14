using Apps.Pipedrive.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Pipedrive.Models.Request.Person;

public class PersonRequest
{
    [Display("Person")]
    [DataSource(typeof(PersonDataHandler))]
    public string PersonId { get; set; }
}