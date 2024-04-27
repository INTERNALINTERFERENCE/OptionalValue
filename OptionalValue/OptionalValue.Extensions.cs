using System.Collections.Generic;

namespace OptionalValue
{
    public static class OptionalValue
    {
        public static int Compare<T>(OptionalValue<T> lhs,OptionalValue<T> rhs ) =>
            lhs.HasValue
                ? rhs.HasValue ? Comparer<T>.Default.Compare( lhs.Value, rhs.Value) : 1
                : rhs.HasValue ? -1 : 0;
    }
}