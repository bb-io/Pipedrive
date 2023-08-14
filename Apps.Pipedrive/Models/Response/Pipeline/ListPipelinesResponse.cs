using Apps.Pipedrive.Models.Dto;

namespace Apps.Pipedrive.Models.Response.Pipeline;

public record ListPipelinesResponse(PipelineDto[] Pipelines);