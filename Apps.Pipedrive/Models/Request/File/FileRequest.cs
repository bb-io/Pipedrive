using Apps.Pipedrive.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Pipedrive.Models.Request.File;

public class FileRequest
{
    [Display("File")]
    [DataSource(typeof(FileDataHandler))] 
    public string FileId { get; set; }
}