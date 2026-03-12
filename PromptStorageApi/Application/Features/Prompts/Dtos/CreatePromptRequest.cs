namespace Application.Features.Prompts.Dtos;

public record CreatePromptRequest
(
    Guid GeneratorId,
    Guid SceneId,
    string Title,
    string? Description,
    string Body,
    string? Tags
);
