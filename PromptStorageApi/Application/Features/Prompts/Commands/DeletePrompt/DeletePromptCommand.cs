using MediatR;

namespace Application.Features.Prompts.Commands.DeletePrompt;

public record DeletePromptCommand(Guid Id) : IRequest<Unit>;
