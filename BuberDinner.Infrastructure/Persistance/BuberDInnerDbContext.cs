using BuberDinner.Domain.MenuAggregate;
using Microsoft.EntityFrameworkCore;

namespace BuberDinner.Infrastructure.Persistance;

public class BuberDinnerDbContent : DbContext
{
    public BuberDinnerDbContent(DbContextOptions<BuberDinnerDbContent> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfigurationsFromAssembly(typeof(BuberDinnerDbContent).Assembly);

        base.OnModelCreating(modelBuilder);
    }
    public DbSet<Menu> Menus { get; set; } = null!;
}