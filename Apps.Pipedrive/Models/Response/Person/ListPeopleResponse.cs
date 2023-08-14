using Apps.Pipedrive.Models.Dto;

namespace Apps.Pipedrive.Models.Response.Person;

public record ListPeopleResponse(PersonDto[] People);