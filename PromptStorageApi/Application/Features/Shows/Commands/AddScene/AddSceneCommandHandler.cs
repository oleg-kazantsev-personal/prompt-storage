using MediatR;
using PromptStorageApi.Application.Features.Shows.Dtos;
using PromptStorageApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using PromptStorageApi.Domain.Entities;

namespace PromptStorageApi.Application.Features.Shows.Commands.AddScene;

public sealed class AddSceneCommandHandler : IRequestHandler<AddSceneCommand, Guid>
{
    private readonly PromptStorageDbContext _db;

    public AddSceneCommandHandler(PromptStorageDbContext db)
    {
        _db = db;
    }

    public async Task<Guid> Handle(AddSceneCommand request, CancellationToken cancellationToken)
    {
        var performance = await _db.Performances
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == request.PerformanceId, cancellationToken);

        if (performance is null)
            throw new KeyNotFoundException($"Performance with id {request.PerformanceId} not found.");

        var scene = new Scene(Guid.NewGuid())
        {
            Title = request.Title,
            Description = request.Description,
            Order = request.Order,
            CreatedBy = "system",
            UpdatedBy = "system",

            PerformanceId = request.PerformanceId
        };

        _db.Scenes.Add(scene);

        await _db.SaveChangesAsync(cancellationToken);

        return scene.Id;   
    }       
}