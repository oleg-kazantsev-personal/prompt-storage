using MediatR;
using PromptStorageApi.Application.Features.Generators.Dtos;
using PromptStorageApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using PromptStorageApi.Domain.Entities;

namespace PromptStorageApi.Application.Features.Generators.Commands.CreateGenerator;

public class CreateGeneratorCommandHandler : IRequestHandler<CreateGeneratorCommand, GeneratorDto>
{
    private readonly PromptStorageDbContext _db;

    public CreateGeneratorCommandHandler(PromptStorageDbContext db)
    {
        _db = db;
    }
    public async Task<GeneratorDto> Handle(CreateGeneratorCommand request, CancellationToken cancellationToken)
    {
        _db.AIGenerators.Add(new AIGenerator(Guid.NewGuid())
        {
            Name = request.Name,
            WebsiteUrl = request.WebsiteUrl,
            CreatedBy = "system",
            UpdatedBy = "system",
        });

        await _db.SaveChangesAsync(cancellationToken);

        var created = new GeneratorDto
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            WebsiteUrl = request.WebsiteUrl
        };

        return created;
    }
}