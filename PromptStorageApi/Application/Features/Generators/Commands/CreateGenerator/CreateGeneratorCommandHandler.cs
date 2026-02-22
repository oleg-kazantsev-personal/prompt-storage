using MediatR;
using PromptStorageApi.Application.Features.Generators.Dtos;

namespace PromptStorageApi.Application.Features.Generators.Commands.CreateGenerator;

public class CreateGeneratorCommandHandler : IRequestHandler<CreateGeneratorCommand, GeneratorDto>
{
    public Task<GeneratorDto> Handle(CreateGeneratorCommand request, CancellationToken cancellationToken)
    {
        // Implementation for creating a generator goes here
        throw new NotImplementedException();
    }
}