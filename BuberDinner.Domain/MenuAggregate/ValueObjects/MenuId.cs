using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.MenuAggregate.ValueObjects;

public sealed class MenuId : ValueObject
{
    public Guid Value { get; private set; }

    private MenuId(Guid value)
    {
        Value = value;
    }

    private MenuId()
    {

    }

    public static MenuId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static MenuId Create(Guid value)
    {
        return new(value);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}