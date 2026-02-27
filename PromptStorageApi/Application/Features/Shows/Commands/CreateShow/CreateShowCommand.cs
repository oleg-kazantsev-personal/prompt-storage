using MediatR;

namespace PromptStorageApi.Application.Features.Shows.Commands.CreateShow;

public sealed record CreateShowCommand(
    string Name,
    string? Description
) : IRequest<Guid>;   
