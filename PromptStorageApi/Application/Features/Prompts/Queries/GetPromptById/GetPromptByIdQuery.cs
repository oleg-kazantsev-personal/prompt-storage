using Application.Features.Prompts.Dtos;
using MediatR;

namespace Application.Features.Prompts.Queries.GetPromptById;

public record GetPromptByIdQuery(Guid Id) : IRequest<PromptDetailsDto>;