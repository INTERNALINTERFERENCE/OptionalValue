using System;

namespace OptionalValue
{
    public interface IValueContainer
    {
        bool HasValue { get; }

        object Value { get; }

        Type ValueType { get; }
    }
}