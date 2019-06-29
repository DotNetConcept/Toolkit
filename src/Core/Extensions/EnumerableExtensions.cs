namespace DotNetConcept.Toolkit.Extensions
{
    using System;
    using System.Collections.Generic;

    using JetBrains.Annotations;

    public static class EnumerableExtensions
    {
        public static void ForEach<T>([NotNull]this IEnumerable<T> source, [NotNull]Action<T> action)
        {
            foreach (var item in source)
            {
                action.Invoke(item);
            }
        }
    }
}
