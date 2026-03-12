using MediatR;

namespace Application.Features.Prompts.Commands.CreatePrompt;

public record CreatePromptCommand
(
    Guid GeneratorId,
    Guid SceneId,
    string Title,
    string? Description,
    string Body,
    string? Tags
) : IRequest<Guid>;
