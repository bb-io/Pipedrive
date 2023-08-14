using Apps.Pipedrive.Models.Dto;

namespace Apps.Pipedrive.Models.Response.Organization;

public record ListOrganizationsResponse(OrganizationDto[] Organizations);