using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Utilities
{
    public static class Extensions
    {
        public static TOut Map<TIn, TOut>(this TIn input, Func<TIn, TOut> function) => function(input);
        public static List<TOut> Map<TIn, TOut>(this List<TIn> inputList, Func<TIn, TOut> function) => inputList.Select(function).ToList();

        public static bool IsNullOrEmpty(this string str) => string.IsNullOrWhiteSpace(str);
    }
}