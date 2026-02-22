using MediatR;
using Microsoft.VisualBasic;
using PromptStorageApi.Application.Features.Generators.Dtos;
using PromptStorageApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace PromptStorageApi.Application.Features.Generators.Queries.GetGeneratorById;

public class GetGeneratorByIdQueryHandler : IRequestHandler<GetGeneratorByIdQuery, GeneratorDto>
{
    private readonly PromptStorageDbContext _db;

    public GetGeneratorByIdQueryHandler(PromptStorageDbContext db)
    {
        _db = db;
    }

    public async Task<GeneratorDto> Handle(GetGeneratorByIdQuery request, CancellationToken cancellationToken)
    {
        var generator = await _db.AIGenerators.Where(x => x.Id == request.Id)
            .AsNoTracking()
            .Select(x => new GeneratorDto
            {
                Id = x.Id,
                Name = x.Name,
                WebsiteUrl = x.WebsiteUrl
            })
            .FirstOrDefaultAsync(cancellationToken);

        if (generator == null)
        {
            throw new KeyNotFoundException($"Generator with id {request.Id} not found.");
        }

        return generator;
    }
}
