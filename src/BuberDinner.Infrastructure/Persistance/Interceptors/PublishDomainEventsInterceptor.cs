using BuberDinner.Domain.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace BuberDinner.Infrastructure.Persistance.Interceptors;

public class PublishDomainEventsInterceptor : SaveChangesInterceptor
{
    private readonly IPublisher _publisher;

    public PublishDomainEventsInterceptor(IPublisher publisher)
    {
        _publisher = publisher;
    }

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        PublishDomainEvents(eventData.Context).GetAwaiter().GetResult();
        return base.SavingChanges(eventData, result);

    }

    public async override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken)
    {
        await PublishDomainEvents(eventData.Context);
        return await base.SavingChangesAsync(eventData, result, cancellationToken);

    }

    private async Task PublishDomainEvents(DbContext? dbcontext)
    {
        if (dbcontext is null)
        {
            return;
        }
        // Get Hold of all the various entities
        var entitiesWithDomainEvents = dbcontext.ChangeTracker.Entries<IHasDomainEvents>()
        .Where(entry => entry.Entity.DomainEvents.Any())
        .Select(entry => entry.Entity)
        .ToList();
        //Get Hold of all the various domain events
        var domainEvents = entitiesWithDomainEvents.SelectMany(entry => entry.DomainEvents).ToList();

        //Clear domain events
        entitiesWithDomainEvents.ForEach(entry => entry.ClearDomainEvents());
        //Publish domain events

        foreach (var domainEvent in domainEvents)
        {
            await _publisher.Publish(domainEvent);
        }

    }
}