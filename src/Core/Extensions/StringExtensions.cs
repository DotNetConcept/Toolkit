namespace DotNetConcept.Toolkit.Extensions
{
    using System.Linq;

    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string source)
        {
            return string.IsNullOrEmpty(source);
        }

        public static bool IsNullOrWhiteSpace(this string source)
        {
            return string.IsNullOrWhiteSpace(source);
        }

        public static string EnsureTrim(this string source, params char[] trimChars)
        {
            if (source == null)
            {
                return null;
            }

            return trimChars?.Any() == true ? source.Trim(trimChars) : source.Trim();
        }
    }
}
