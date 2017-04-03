using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public static class StringExtensions
    {
        public static string ToAscii(this string source, char nil = ' ')
        {
            const char max = '\u007F';
            return source.Select(c => c > max ? nil : c).ToText();
        }

        public static string LatinToAscii(this string source)
        {
            var newStringBuilder = new StringBuilder();
            newStringBuilder.Append(source.Normalize(NormalizationForm.FormKD)
                                            .Where(x => x < 128)
                                            .ToArray());
            return newStringBuilder.ToString();
        }

        public static string Left(this string source, int maxChars)
        {
            if (string.IsNullOrEmpty(source) || maxChars <= 0)
                return "";
            return source.Substring(0, Math.Min(maxChars, source.Length));
        }

        public static string Right(this string source, int maxChars)
        {
            if (string.IsNullOrEmpty(source) || maxChars <= 0)
                return "";
            if (maxChars >= source.Length)
                return source;
            return source.Substring(source.Length - maxChars, maxChars);
        }

        public static string ToText(this IEnumerable<char> source)
        {
            var buffer = new StringBuilder();
            foreach (var c in source)
                buffer.Append(c);
            return buffer.ToString();
        }

        public static int ToInt(this string n)
        {
            if (string.IsNullOrEmpty(n) || !int.TryParse(n, out int i))
                return 0;

            return i;
        }
    }
}
