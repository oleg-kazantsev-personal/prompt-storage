using MediatR;
using PromptStorageApi.Application.Features.Generators.Dtos;

namespace PromptStorageApi.Application.Features.Generators.Commands.CreateGenerator;

public sealed record CreateGeneratorCommand(string Name, string? WebsiteUrl) : IRequest<GeneratorDto>;