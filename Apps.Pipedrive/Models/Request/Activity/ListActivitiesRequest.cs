﻿using Apps.Pipedrive.DataSourceHandlers.EnumDataHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Pipedrive.Models.Request.Activity;

public class ListActivitiesRequest
{
    [DataSource(typeof(ActivityTypeDataHandler))]
    public string? Type { get; set; }
    
    [Display("Start date")]
    public DateTime? StartDate { get; set; }

    [Display("End date")]
    public DateTime? EndDate { get; set; }

    [Display("Is activity done")]
    public bool? IsActivityDone { get; set; }
}