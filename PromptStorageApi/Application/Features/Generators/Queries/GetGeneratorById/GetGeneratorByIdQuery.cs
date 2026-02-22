using MediatR;
using PromptStorageApi.Application.Features.Generators.Dtos;

namespace PromptStorageApi.Application.Features.Generators.Queries.GetGeneratorById;

public sealed record GetGeneratorByIdQuery(Guid Id) : IRequest<GeneratorDto>;