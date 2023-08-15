using Blackbird.Applications.Sdk.Common;
using Pipedrive;

namespace Apps.Pipedrive.Models.Dto;

public class DealDto
{
    [Display("ID")]
    public string Id { get; set; }
    public string Title { get; set; }
    public decimal Value { get; set; }
    public string Currency { get; set; }
    
    [Display("User ID")]
    public string? UserId { get; set; }
    
    [Display("Person ID")]
    public string? PersonId { get; set; }
    
    [Display("Organization ID")]
    public string? OrgId { get; set; }
    
    [Display("Stage ID")]
    public string StageId { get; set; }
    public string Status { get; set; }
    public double? Probability { get; set; }
    
    [Display("Lost reason")]
    public string LostReason { get; set; }
    
    [Display("Add time")]
    public DateTime? AddTime { get; set; }
    
    [Display("Close time")]
    public DateTime? CloseTime { get; set; }
    
    [Display("Lost time")]
    public DateTime? LostTime { get; set; }
    
    [Display("Won time")]
    public DateTime? WonTime { get; set; }
    
    [Display("Expected close date")]
    public DateTime? ExpectedCloseDate { get; set; }
    
    public DealDto(Deal deal)
    {
        Id = deal.Id.ToString();
        Title = deal.Title;
        Value = deal.Value;
        Currency = deal.Currency;
        UserId = deal.UserId.Value.ToString();
        PersonId = deal.PersonId?.Value.ToString();
        OrgId = deal.OrgId?.Value.ToString();
        StageId = deal.StageId.ToString();
        Status = deal.Status.ToString();
        Probability = deal.Probability;
        LostReason = deal.LostReason;
        AddTime = deal.AddTime;
        CloseTime = deal.CloseTime;
        LostTime = deal.LostTime;
        WonTime = deal.WonTime;
        ExpectedCloseDate = deal.ExpectedCloseDate;
    }
    
    public DealDto(WebhookDeal deal)
    {
        Id = deal.Id.ToString();
        Title = deal.Title;
        Value = deal.Value;
        Currency = deal.Currency;
        UserId = deal.UserId.ToString();
        PersonId = deal.PersonId.ToString();
        OrgId = deal.OrgId.ToString();
        StageId = deal.StageId.ToString();
        Status = deal.Status.ToString();
        Probability = deal.Probability;
        LostReason = deal.LostReason;
        AddTime = deal.AddTime;
        CloseTime = deal.CloseTime;
        LostTime = deal.LostTime;
        WonTime = deal.WonTime;
        ExpectedCloseDate = deal.ExpectedCloseDate;
    }
}