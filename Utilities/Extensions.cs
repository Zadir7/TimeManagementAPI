using System;

namespace Utilities
{
    public static class Extensions
    {
        public static TOut Map<TIn, TOut>(this TIn input, Func<TIn, TOut> function) => function(input);

        public static bool IsNullOrEmpty(this string str) => string.IsNullOrWhiteSpace(str);
    }
}