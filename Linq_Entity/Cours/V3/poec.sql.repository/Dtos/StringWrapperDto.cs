namespace poec.sql.repository.Dtos;

public class StringWrapperDto : IEquatable<StringWrapperDto>
{
    public string Value { get; set; }

    public StringWrapperDto(string value)
    {
        Value = value;
    }

    public bool Equals(StringWrapperDto? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Value == other.Value;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;

        return Equals((StringWrapperDto)obj);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }
}