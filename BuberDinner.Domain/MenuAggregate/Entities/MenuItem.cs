using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.MenuAggregate.ValueObjects;

namespace BuberDinner.Domain.MenuAggregate.Entities;

public sealed class MenuItem : Entity<MenuItemId>
{
    public string Name { get; private set; }
    public string Description { get; private set; }

    private MenuItem(string name, string description, MenuItemId? id = null)
        : base(id ?? MenuItemId.CreateUnique())
    {
        Name = name;
        Description = description;
    }

    public static MenuItem Create(
        string name,
        string description)
    {
        return new(
            name,
            description);
    }

    private MenuItem()
    {

    }

}
