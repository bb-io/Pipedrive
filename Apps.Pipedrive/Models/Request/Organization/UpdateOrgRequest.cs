namespace Apps.Pipedrive.Models.Request.Organization;

public class UpdateOrgRequest : AddOrgRequest
{
    public new string? Name { get; set; }
}