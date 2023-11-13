using BuberDinner.Application.Common.Interfaces.Persistance;
using BuberDinner.Domain.MenuAggregate;

namespace BuberDinner.Infrastructure.Persistance;

public class MenuRepository : IMenuRepository
{
    private readonly BuberDinnerDbContent _dbContext;

    public MenuRepository(BuberDinnerDbContent dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(Menu menu)
    {
        _dbContext.Add(menu);

        _dbContext.SaveChanges();
    }
}