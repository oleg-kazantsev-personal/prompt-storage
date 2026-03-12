namespace Application.Features.Prompts.Dtos;

public record UpdatePromptRequest
(
    Guid Id,
    Guid GeneratorId,
    Guid SceneId,
    string Title,
    string? Description,
    string Body,
    string? Tags
);
