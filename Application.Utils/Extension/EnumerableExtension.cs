using System;
using System.Collections.Generic;

namespace Application.Utils.Extension
{
    public static class EnumerableExtension
    {
        public static void ForEach<T>(this IEnumerable<T> value, Action<T> action)
        {
            foreach (T item in value)
            {
                action(item);
            }
        }
    }
}