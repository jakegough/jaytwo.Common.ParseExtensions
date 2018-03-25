using System;
using System.Globalization;
using System.Reflection;

namespace jaytwo.Common.ParseExtensions
{
    public static class ParseEnumExtensions
    {
        public static T ParseEnum<T>(this string value) where T : struct
        {
#if NETFRAMEWORK || NETSTANDARD_GTE_2_0
            if (!typeof(T).IsEnum)
            {
                throw new NotSupportedException("T must be an Enum");
            }
#elif !NETSTANDARD_GTE_2_0
            if (!typeof(T).GetTypeInfo().IsEnum)
            {
                throw new NotSupportedException("T must be an Enum");
            }
#endif

            return (T)Enum.Parse(typeof(T), value, true);
        }

        public static T? ParseEnumOrNull<T>(this string value) where T : struct
        {
            try
            {
                return value.ParseEnum<T>();
            }
            catch
            {
                return null;
            }
        }
    }
}
