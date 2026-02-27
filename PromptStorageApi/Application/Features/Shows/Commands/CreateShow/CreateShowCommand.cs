using MediatR;

namespace Application.Features.Shows.Commands.CreateShow;

public sealed record CreateShowCommand(
    string Name
) : IRequest<Guid>;   
