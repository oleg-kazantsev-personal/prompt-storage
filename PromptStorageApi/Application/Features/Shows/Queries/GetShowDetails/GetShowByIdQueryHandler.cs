using MediatR;
using PromptStorageApi.Application.Features.Shows.Dtos;
using PromptStorageApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace PromptStorageApi.Application.Features.Shows.Queries.GetShowDetails;

public sealed class GetShowByIdQueryHandler : IRequestHandler<GetShowByIdQuery, ShowDetailsDto>
{
    private readonly PromptStorageDbContext _dbContext;

    public GetShowByIdQueryHandler(PromptStorageDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ShowDetailsDto> Handle(GetShowByIdQuery request, CancellationToken cancellationToken)
    {
        var show = await _dbContext.Shows
            .Include(s => s.Performances)
                .ThenInclude(p => p.Scenes)
            .FirstOrDefaultAsync(s => s.Id == request.Id, cancellationToken);

        if (show == null)
        {
            throw new KeyNotFoundException($"Show with ID {request.Id} not found.");
        }

        return new ShowDetailsDto
        {
            Id = show.Id,
            Name = show.Name,
            Performances = show.Performances.Select(p => new PerformanceDto
            {
                Id = p.Id,
                Title = p.Title,
                DateUtc = p.DateUtc,
                Scenes = p.Scenes.Select(s => new SceneDto
                {
                    Id = s.Id,
                    Title = s.Title,
                    Order = s.Order
                }).ToList()
            }).ToList()
        };
    }
}
