using MediatR;
using PromptStorageApi.Application.Features.Shows.Dtos;

namespace PromptStorageApi.Application.Features.Shows.Commands.DeleteShow;

public sealed record DeleteShowCommand(Guid Id) : IRequest<Unit>;