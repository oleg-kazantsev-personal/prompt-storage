namespace Application.Features.Prompts.Dtos;

public record UpdatePromptRequest
(
    Guid Id,
    string Title,
    Guid GeneratorId,
    string GeneratorName,
    Guid SceneId,
    string SceneTitle,
    string? Tags,
    DateTime CreatedUtc,
    DateTime? UpdatedUtc,
    string Body,
    string? ExampleImageUrl,
    byte[] RowVersion
);
