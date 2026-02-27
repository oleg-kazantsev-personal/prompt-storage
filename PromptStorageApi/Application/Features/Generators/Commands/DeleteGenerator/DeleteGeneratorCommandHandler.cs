using MediatR;
using PromptStorageApi.Application.Features.Generators.Dtos;
using PromptStorageApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using PromptStorageApi.Domain.Entities;

namespace PromptStorageApi.Application.Features.Generators.Commands.DeleteGenerator;

public class DeleteGeneratorCommandHandler : IRequestHandler<DeleteGeneratorCommand, Unit>
{
    private readonly PromptStorageDbContext _db;

    public DeleteGeneratorCommandHandler(PromptStorageDbContext db)
    {
        _db = db;
    }

    public async Task<Unit> Handle(DeleteGeneratorCommand request, CancellationToken cancellationToken)
    {
        var generator = await _db.AIGenerators.FindAsync(new object[] { request.Id }, cancellationToken);

        if (generator == null)
        {
            throw new KeyNotFoundException($"Generator with ID {request.Id} not found.");
        }

        _db.AIGenerators.Remove(generator);
        await _db.SaveChangesAsync(cancellationToken);
    
        return Unit.Value;
    }
}
