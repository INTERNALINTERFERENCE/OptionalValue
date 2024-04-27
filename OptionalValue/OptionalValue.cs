using System;

namespace OptionalValue
{
    public readonly struct OptionalValue<T> 
        : IValueContainer,
            IEquatable<OptionalValue<T>>,
            IComparable<OptionalValue<T>>
    {
        private readonly T _value;

        public static bool operator ==(OptionalValue<T> lhs, OptionalValue<T> rhs) => 
            lhs.Equals(rhs);
        
        public static bool operator !=(OptionalValue<T> lhs, OptionalValue<T> rhs) =>
            !lhs.Equals(rhs);
        
        public static bool operator ==(OptionalValue<T> lhs, T rhs) => 
            lhs.HasValue && lhs.Value.Equals(rhs);
        
        public static bool operator !=(OptionalValue<T> lhs, T rhs ) =>
            lhs.HasValue && !lhs.Value.Equals( rhs );
        
        public static bool operator ==(T lhs, OptionalValue<T> rhs) =>
            rhs.HasValue && (lhs?.Equals(rhs.Value) == true);
        
        public static bool operator !=(T lhs, OptionalValue<T> rhs) =>
            rhs.HasValue && (lhs?.Equals(rhs.Value) == false);

        public static implicit operator OptionalValue<T>(T value) => new(value);
        
        public static implicit operator T(OptionalValue<T> value) => value.Value;

        private OptionalValue(bool hasValue, T value)
        {
            HasValue = hasValue; 
            _value = value;
        }

        public OptionalValue(T value)
        {
            HasValue = true; 
            _value = value;
        }

        public OptionalValue(OptionalValue<T> other)
        {
            HasValue = other.HasValue;
            _value = other._value;
        }

        public static OptionalValue<T> Undefined =>new(false, default);

        public bool HasValue { get; }

        public T Value => HasValue 
            ? _value 
            : throw new InvalidOperationException("value is undefined");

        object IValueContainer.Value => Value;

        Type IValueContainer.ValueType => typeof(T);

        public override bool Equals(object obj) =>
            obj is OptionalValue<T> other
            && Equals(other);

        public bool Equals(OptionalValue<T> other) =>
            CompareTo(other) == 0;

        public int CompareTo(OptionalValue<T> other) =>
            OptionalValue.Compare(this, other);

        public override int GetHashCode() =>
            HasValue ? Value.GetHashCode() : 0;
    }
}