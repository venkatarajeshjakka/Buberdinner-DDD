using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.MenuAggregate.Entities;
using BuberDinner.Domain.MenuAggregate.Events;
using BuberDinner.Domain.MenuAggregate.ValueObjects;
using BuberDinner.Domain.MenuReviewAggregate.ValueObjects;

namespace BuberDinner.Domain.MenuAggregate;

public sealed class Menu : AggregateRoot<MenuId, Guid>
{
    private readonly List<MenuSection> _sections = new();

    private readonly List<DinnerId> _dinnerIds = new();

    private readonly List<MenuReviewId> _menuReviewIds = new();

    public string Name { get; private set; }
    public string Description { get; private set; }
    public AverageRating AverageRating { get; private set; }

    public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();

    public HostId HostId { get; private set; }

    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();

    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();

    public DateTime CreateDateTime { get; private set; }

    public DateTime UpdateDeteTime { get; private set; }

    private Menu(
        MenuId menuId,
         HostId hostId,
        string name,
        string description,
        AverageRating averageRating,
        List<MenuSection> sections
    ) : base(menuId)
    {
        Name = name;
        Description = description;
        HostId = hostId;
        _sections = sections;
        AverageRating = averageRating;
    }

    public static Menu Create(
        string hostId,
        string name,
        string description,
        List<MenuSection>? menuSections = null
       )
    {
        var menu = new Menu(
            MenuId.CreateUnique(),
            HostId.Create(hostId),
            name,
            description,
            AverageRating.CreateNew(),
            menuSections ?? new()
        );

        menu.AddDomainEvent(new MenuCreated(menu));
        return menu;

    }

    public void AddMenuSection(List<MenuSection> sections)
    {
        _sections.AddRange(sections);
    }

    private Menu()
    {

    }
}