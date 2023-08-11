using Blackbird.Applications.Sdk.Common;

namespace Apps.Pipedrive.Models.Request.Deal;

public class CreateDealRequest
{
    [Display("Title")]
    public string Title { get; set; }

    // TODO: Check if decimal works with the sdk
    [Display("Value")]
    public decimal Value { get; set; }

    [Display("Currency")]
    public string? Currency { get; set; }

    [Display("User ID")]
    public string? UserId { get; set; }

    [Display("Person ID")]
    public string? PersonId { get; set; }

    [Display("Organization ID")]
    public string? OrgId { get; set; }

    [Display("Stage ID")]
    public string? StageId { get; set; }

    [Display("Status")]
    public string? Status { get; set; }

    [Display("Probability")]
    public double? Probability { get; set; }

    [Display("Lost reason")]
    public string? LostReason { get; set; }

    [Display("Is private")]
    public bool? IsPrivate { get; set; }

    [Display("Add time")]
    public DateTime? AddTime { get; set; }

    [Display("Close time")]
    public DateTime? CloseTime { get; set; }

    [Display("Lost time")]
    public DateTime? LostTime { get; set; }

    [Display("First won time")]
    public DateTime? FirstWonTime { get; set; }

    [Display("Won time")]
    public DateTime? WonTime { get; set; }

    [Display("Expected close date")]
    public DateTime? ExpectedCloseDate { get; set; }
}