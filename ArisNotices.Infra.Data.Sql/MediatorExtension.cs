
namespace ArisNotices.Infra.Data.Sql;
static class MediatorExtension
{
    public static async Task DispatchDomainEventsAsync(this IMediator mediator, ArisNoticesContext ctx)
    {
        var domainEntities = ctx.ChangeTracker
            .Entries<EntityBase<Guid>>()
            .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());

        var domainEvents = domainEntities
            .SelectMany(x => x.Entity.DomainEvents)
            .ToList();

        domainEntities.ToList()
            .ForEach(entity => entity.Entity.ClearDomainEvents());

        foreach (var domainEvent in domainEvents)
            await mediator.Publish(domainEvent);
    }
}

