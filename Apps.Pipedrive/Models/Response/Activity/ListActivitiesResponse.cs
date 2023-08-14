using Apps.Pipedrive.Models.Dto;

namespace Apps.Pipedrive.Models.Response.Activity;

public record ListActivitiesResponse(ActivityDto[] Activities);