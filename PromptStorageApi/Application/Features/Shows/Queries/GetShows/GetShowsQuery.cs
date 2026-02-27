using PromptStorageApi.Application.Features.Shows.Dtos;
using MediatR;

public sealed record GetShowsQuery : IRequest<IEnumerable<ShowDetailsDto>>;
