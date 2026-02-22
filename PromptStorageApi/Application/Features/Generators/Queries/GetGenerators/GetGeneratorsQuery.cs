using MediatR;
using PromptStorageApi.Application.Features.Generators.Dtos;

namespace PromptStorageApi.Application.Features.Generators.Queries.GetGenerators;    

public sealed record GetGeneratorsQuery() : IRequest<IEnumerable<GeneratorDto>>;