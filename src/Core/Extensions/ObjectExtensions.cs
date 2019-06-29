namespace DotNetConcept.Toolkit.Extensions
{
    using System.Linq;

    using JetBrains.Annotations;

    public static class ObjectExtensions
    {
        public static bool In<T>([NotNull]this T source, params T[] values)
        {
            if (values?.Any() != true)
            {
                return false;
            }

            return values.Any(x => x.Equals(source));
        }
    }
}
