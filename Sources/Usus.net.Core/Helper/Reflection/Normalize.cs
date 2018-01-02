using System;

namespace andrena.Usus.net.Core.Helper.Reflection
{
    public static class Normalize
    {
        public static string TypeName(string typeName)
        {
            return WhiteSpaces(ByRefs(GenericName(SubTypeName(typeName))));
        }

        public static string MethodName(this string methodName)
        {
            return WhiteSpaces(ByRefs(GenericName(PropertyName(methodName))));
        }

        public static string FullMethodName(this string fullMethodName)
        {
            var parts = fullMethodName.Split(new [] {"::"}, StringSplitOptions.RemoveEmptyEntries);
            return TypeName(parts[0]) + "." + WhiteSpaces(ByRefs(GenericName(SubTypeName(PropertyName(parts[1])))));
        }

        internal static string PropertyName(string methodName)
        {
            return methodName
                .ReplaceIfStartsWith("get_", "()", ".get()")
                .ReplaceIfStartsWith("set_", "(", ".set(");
        }

        internal static string GenericName(string methodName)
        {
            return methodName.ReplaceRegex("`.*?\\[", "[").Replace("[", "<").Replace("]", ">").Trim();
        }

        internal static string ByRefs(string methodName)
        {
            return methodName.Replace(" ByRef,", ",").Replace(" ByRef)", ")").Replace("&", "");
        }

        internal static string WhiteSpaces(string methodName)
        {
            return methodName.Replace(", ", ",");
        }

        internal static string SubTypeName(string subTypeName)
        {
            return subTypeName.Replace("+", ".").Replace("/", ".");
        }
    }
}
