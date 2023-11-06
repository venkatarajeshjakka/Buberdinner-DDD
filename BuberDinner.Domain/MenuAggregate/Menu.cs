using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.MenuAggregate.Entities;
using BuberDinner.Domain.MenuAggregate.ValueObjects;
using BuberDinner.Domain.MenuReviewAggregate.ValueObjects;

namespace BuberDinner.Domain.MenuAggregate;

public sealed class Menu : AggregateRoot<MenuId>
{
    private readonly List<MenuSection> _sections = new();

    private readonly List<DinnerId> _dinnerIds = new();

    private readonly List<MenuReviewId> _menuReviewIds = new();

    public string Name { get; }
    public string Description { get; }
    public AverageRating AverageRating { get; }

    public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();

    public HostId HostId { get; }

    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();

    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();

    public DateTime CreateDateTime { get; }

    public DateTime UpdateDeteTime { get; }

    private Menu(
        MenuId menuId,
        string name,
        string description,
        HostId hostId,
        DateTime createDateTime,
        DateTime updateDateTime
    ) : base(menuId)
    {
        Name = name;
        Description = description;
        HostId = hostId;
        CreateDateTime = createDateTime;
        UpdateDeteTime = updateDateTime;
    }

    public static Menu Create(
        string name,
        string description,
        HostId hostId)
    {
        return new(
            MenuId.CreateUnique(),
            name,
            description,
            hostId,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }

    public void AddMenuSection(List<MenuSection> sections)
    {
        _sections.AddRange(sections);
    }
}