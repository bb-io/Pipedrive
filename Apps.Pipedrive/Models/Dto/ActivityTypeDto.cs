using Blackbird.Applications.Sdk.Common;
using Pipedrive;

namespace Apps.Pipedrive.Models.Dto;

public class ActivityTypeDto
{
    [Display("ID")]
    public string Id { get; set; }

    [Display("Order number")]
    public string OrderNr { get; set; }

    public string Name { get; set; }

    [Display("Key string")]
    public string KeyString { get; set; }

    [Display("Icon")]
    public string IconKey { get; set; }

    [Display("Is active")]
    public bool IsActive { get; set; }

    public string Color { get; set; }
    
    [Display("Is custom")]
    public bool IsCustom { get; set; }

    [Display("Add time")]
    public DateTime? AddTime { get; set; }
    
    public ActivityTypeDto(ActivityType type)
    {
        Id = type.Id.ToString();
        OrderNr = type.OrderNr.ToString();
        Name = type.Name;
        KeyString = type.KeyString;
        IconKey = type.IconKey.ToString();
        IsActive = type.ActiveFlag;
        Color = type.Color;
        IsCustom = type.IsCustomFlag;
        AddTime = type.AddTime;
    }
}