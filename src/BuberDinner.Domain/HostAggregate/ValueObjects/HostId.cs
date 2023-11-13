using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.HostAggregate.ValueObjects;

public sealed class HostId : ValueObject
{
    public string Value { get; private set; }

    private HostId(string value)
    {
        Value = value;
    }

    public static HostId Create(string value)
    {
        return new(value);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    private HostId()
    {

    }
}