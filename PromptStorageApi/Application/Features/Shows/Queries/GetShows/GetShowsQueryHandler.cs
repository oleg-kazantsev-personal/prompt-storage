using MediatR;
using PromptStorageApi.Application.Features.Shows.Dtos;
using PromptStorageApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace PromptStorageApi.Application.Features.Shows.Queries.GetShows;

public sealed class GetShowsQueryHandler : IRequestHandler<GetShowsQuery, IEnumerable<ShowDetailsDto>>
{
    private readonly PromptStorageDbContext _db;

    public GetShowsQueryHandler(PromptStorageDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<ShowDetailsDto>> Handle(GetShowsQuery request, CancellationToken cancellationToken)
    {
        var shows = await _db.Shows
            .Select(s => new ShowDetailsDto
            {
                Id = s.Id,
                Name = s.Name
            })
            .ToListAsync(cancellationToken);

        return shows;
    }
}