using MediatR;
using PromptStorageApi.Application.Features.Shows.Dtos;
using PromptStorageApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using PromptStorageApi.Domain.Entities;

namespace Application.Features.Shows.Commands.CreateShow;

public sealed class CreateShowCommandHandler : IRequestHandler<CreateShowCommand, Guid>
{
    private readonly PromptStorageDbContext _db;

    public CreateShowCommandHandler(PromptStorageDbContext db)
    {
        _db = db;
    }

    public async Task<Guid> Handle(CreateShowCommand request, CancellationToken cancellationToken)
    {
        var entity = new Show(Guid.NewGuid())
        {
            Name = request.Name,
            CreatedBy = "system",
            UpdatedBy = "system",
        };

        _db.Shows.Add(entity);

        await _db.SaveChangesAsync(cancellationToken);

        return entity.Id;   
    }       
}
