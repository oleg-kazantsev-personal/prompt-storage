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
        var entity = new AIGenerator(Guid.NewGuid())
        {
            Name = request.Name,
            WebsiteUrl = request.WebsiteUrl,
            CreatedBy = "system",
            UpdatedBy = "system",
        };

        _db.AIGenerators.Add(entity);

        await _db.SaveChangesAsync(cancellationToken);

        var created = new GeneratorDto
        {
            Id = entity.Id,
            Name = entity.Name,
            WebsiteUrl = entity.WebsiteUrl
        };

        return created;
    }
}