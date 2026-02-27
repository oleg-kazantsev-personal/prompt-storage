using MediatR;

namespace PromptStorageApi.Application.Features.Shows.Commands.AddScene;

public record AddSceneCommand(
    Guid PerformanceId, 
    string Title,
    string? Description,
    int Order) 
    : IRequest<Guid>;