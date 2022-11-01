using iPractice.Domain.SeedWork;
using MediatR;

namespace iPractice.Infrastructure;

static class MediatorExtension
{
    public static async Task DispatchDomainEventsAsync(this IMediator mediator, ApplicationDbContext ctx)
    {
        IEnumerable<Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<Entity>> domainEntities = ctx.ChangeTracker
            .Entries<Entity>()
            .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());

        List<INotification> domainEvents = domainEntities
            .SelectMany(x => x.Entity.DomainEvents)
            .ToList();

        domainEntities.ToList()
            .ForEach(entity => entity.Entity.ClearDomainEvents());

        foreach (INotification? domainEvent in domainEvents)
            await mediator.Publish(domainEvent);
    }
}
