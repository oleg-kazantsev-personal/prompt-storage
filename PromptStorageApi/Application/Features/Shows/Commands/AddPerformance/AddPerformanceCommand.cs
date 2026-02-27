using MediatR;

namespace PromptStorageApi.Application.Features.Shows.Commands.AddPerformance;

public record AddPerformanceCommand(
    Guid ShowId, 
    string Title,
    string? Description,
    DateTime? DateUtc) 
    : IRequest<Guid>;