using MediatR;
using PromptStorageApi.Application.Features.Generators.Dtos;

namespace PromptStorageApi.Application.Features.Generators.Commands.DeleteGenerator;

public sealed record DeleteGeneratorCommand(Guid Id) : IRequest<Unit>;
