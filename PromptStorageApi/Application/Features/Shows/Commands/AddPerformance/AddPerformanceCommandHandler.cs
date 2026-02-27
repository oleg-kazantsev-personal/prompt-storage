using MediatR;
using PromptStorageApi.Application.Features.Shows.Dtos;
using PromptStorageApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using PromptStorageApi.Domain.Entities;

namespace PromptStorageApi.Application.Features.Shows.Commands.AddPerformance;

public sealed class AddPerformanceCommandHandler : IRequestHandler<AddPerformanceCommand, Guid>
{
    private readonly PromptStorageDbContext _db;

    public AddPerformanceCommandHandler(PromptStorageDbContext db)
    {
        _db = db;
    }

    public async Task<Guid> Handle(AddPerformanceCommand request, CancellationToken cancellationToken)
    {
        var show = await _db.Shows
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.Id == request.ShowId, cancellationToken);

        if (show is null)
            throw new KeyNotFoundException($"Show with id {request.ShowId} not found.");

        var performance = new Performance(Guid.NewGuid())
        {
            Title = request.Title,
            Description = request.Description,
            DateUtc = request.DateUtc,
            CreatedBy = "system",
            UpdatedBy = "system",

            ShowId = request.ShowId
        };

        _db.Performances.Add(performance);

        await _db.SaveChangesAsync(cancellationToken);

        return performance.Id;   
    }       
}