using PromptStorageApi.Application.Features.Shows.Dtos;
using MediatR;

namespace PromptStorageApi.Application.Features.Shows.Queries.GetShowDetails;

public sealed record GetShowByIdQuery(Guid Id) : IRequest<ShowDetailsDto>;
