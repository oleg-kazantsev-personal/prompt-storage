using MediatR;
using PromptStorageApi.Application.Features.Shows.Dtos;
using PromptStorageApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using PromptStorageApi.Domain.Entities;

namespace PromptStorageApi.Application.Features.Shows.Commands.DeleteShow;

public class DeleteShowCommandHandler : IRequestHandler<DeleteShowCommand, Unit>
{
    private readonly PromptStorageDbContext _db;

    public DeleteShowCommandHandler(PromptStorageDbContext db)
    {
        _db = db;
    }

    public async Task<Unit> Handle(DeleteShowCommand request, CancellationToken cancellationToken)
    {
        var show = await _db.Shows.FindAsync(new object[] { request.Id }, cancellationToken);

        if (show == null)
        {
            throw new KeyNotFoundException($"Show with ID {request.Id} not found.");
        }

        // Remove all dependent entities
        var performances = await _db.Performances
            .Where(p => p.ShowId == request.Id)
            .ToListAsync(cancellationToken);
        
        foreach (var performance in performances)
        {
            var scenes = await _db.Scenes
            .Where(s => s.PerformanceId == performance.Id)
            .ToListAsync(cancellationToken);
            
            _db.Scenes.RemoveRange(scenes);
        }
        
        _db.Performances.RemoveRange(performances);
        _db.Shows.Remove(show);
        await _db.SaveChangesAsync(cancellationToken);
    
        return Unit.Value;
    }
}
