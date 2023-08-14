namespace Apps.Pipedrive.Models.Request.Person;

public class UpdatePersonRequest : AddPersonRequest
{
    public new string? Name { get; set; }
}