namespace DotNetConcept.Toolkit.Core.Extensions
{
    using System;
    using System.Collections.Generic;

    using Ardalis.GuardClauses;

    public static class EnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            Guard.Against.Null(source, nameof(source));
            Guard.Against.Null(action, nameof(action));

            foreach (var item in source)
            {
                action.Invoke(item);
            }
        }
    }
}
