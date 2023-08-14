using Apps.Pipedrive.Models.Dto;

namespace Apps.Pipedrive.Models.Response.File;

public record ListFilesResponse(FileDto[] Files);