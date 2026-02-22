using MediatR;
using Microsoft.VisualBasic;
using PromptStorageApi.Application.Features.Generators.Dtos;
using PromptStorageApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace PromptStorageApi.Application.Features.Generators.Queries.GetGenerators;

public class GetGeneratorsQueryHandler : IRequestHandler<GetGeneratorsQuery, IEnumerable<GeneratorDto>>
{
    private readonly PromptStorageDbContext _db;

    public GetGeneratorsQueryHandler(PromptStorageDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<GeneratorDto>> Handle(GetGeneratorsQuery request, CancellationToken cancellationToken)
    {
        var allGenerators = await _db.AIGenerators
            .AsNoTracking()
            .OrderBy(x => x.Name)
            .Select(x => new GeneratorDto
            {
                Id = x.Id,
                Name = x.Name,
                WebsiteUrl = x.WebsiteUrl
            })
            .ToListAsync(cancellationToken);

        return allGenerators;
    }
}
