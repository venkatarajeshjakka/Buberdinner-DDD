using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.MenuAggregate;
using BuberDinner.Infrastructure.Persistance.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace BuberDinner.Infrastructure.Persistance;

public class BuberDinnerDbContent : DbContext
{
    private readonly PublishDomainEventsInterceptor _domainEventsInterceptor;
    public BuberDinnerDbContent(DbContextOptions<BuberDinnerDbContent> options,
    PublishDomainEventsInterceptor domainEventsInterceptor)
        : base(options)
    {
        _domainEventsInterceptor = domainEventsInterceptor;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Ignore<List<IDomainEvent>>()
            .ApplyConfigurationsFromAssembly(typeof(BuberDinnerDbContent).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_domainEventsInterceptor);
        base.OnConfiguring(optionsBuilder);
    }
    public DbSet<Menu> Menus { get; set; } = null!;
}