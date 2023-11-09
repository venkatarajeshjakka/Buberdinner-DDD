using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.HostAggregate.ValueObjects;

public sealed class HostId : ValueObject
{
    public Guid Value { get; private set; }

    private HostId(Guid value)
    {
        Value = value;
    }

    public static HostId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static HostId Create(Guid value)
    {
        return new(value);
    }

    public static HostId Create(string value)
    {
        return new(new(value));
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    private HostId()
    {

    }
}