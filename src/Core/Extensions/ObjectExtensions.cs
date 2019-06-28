namespace DotNetConcept.Toolkit.Core.Extensions
{
    using System.Linq;

    using Ardalis.GuardClauses;

    public static class ObjectExtensions
    {
        public static bool In<T>(this T source, params T[] values)
        {
            Guard.Against.Null(source, nameof(source));

            if (values?.Any() != true)
            {
                return false;
            }

            return values.Any(x => x.Equals(source));
        }
    }
}
