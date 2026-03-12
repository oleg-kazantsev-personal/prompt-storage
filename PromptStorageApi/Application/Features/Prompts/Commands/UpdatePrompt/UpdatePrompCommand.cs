using MediatR;

namespace Application.Features.Prompts.Commands.UpdatePrompt;

public record UpdatePromptCommand
(
    Guid GeneratorId,
    Guid SceneId,
    string Title,
    string? Description,
    string Body,
    string? Tags
) : IRequest<Guid>;
