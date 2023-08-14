using Apps.Pipedrive.Models.Dto;

namespace Apps.Pipedrive.Models.Response.User;

public record ListUsersResponse(UserDto[] Users);