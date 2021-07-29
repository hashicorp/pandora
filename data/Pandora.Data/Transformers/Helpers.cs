using System;
using System.Collections.Generic;
using System.Reflection;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Data.Transformers
{
    internal static class Helpers
    {
        public static bool IsNativeType(Type input)
        {
            var nativeTypes = new List<Type>
            {
                typeof(bool),
                typeof(byte),
                typeof(DateTime),
                typeof(float),
                typeof(int),
                typeof(object),
                typeof(string),
            };
            return nativeTypes.Contains(input);
        }

        public static bool IsPandoraCustomType(Type input)
        {
            var customTypes = new List<Type>
            {
                typeof(Location),
                typeof(Tags),
                typeof(SystemAssignedIdentity),
                typeof(SystemUserAssignedIdentityList),
                typeof(SystemUserAssignedIdentityMap),
                typeof(UserAssignedIdentityList),
                typeof(UserAssignedIdentityMap),
            };
            return customTypes.Contains(input);
        }

        internal static bool HasAttribute<T>(this MemberInfo info) where T : Attribute
        {
            return info.GetCustomAttribute<T>() != null;
        }

        internal static bool IsAGenericDictionary(this Type input)
        {
            return input.IsGenericType && input.GetGenericTypeDefinition() == typeof(Dictionary<,>);
        }

        internal static bool IsAGenericList(this Type input)
        {
            return input.IsGenericType && input.GetGenericTypeDefinition() == typeof(List<>);
        }

        internal static Type GenericListElement(this Type input)
        {
            if (!input.IsAGenericList())
            {
                throw new NotSupportedException($"unsupported list type {input.Name}");
            }

            return input.GetGenericArguments()[0];
        }

        internal static Type GenericDictionaryValueElement(this Type input)
        {
            if (!input.IsAGenericDictionary())
            {
                throw new NotSupportedException($"unsupported dictionary type {input.Name}");
            }

            var keyType = input.GetGenericArguments()[0];
            if (keyType != typeof(string))
            {
                throw new NotSupportedException($"Dictionaries are only supported String keys at this time but got {keyType.FullName}");
            }

            return input.GetGenericArguments()[1];
        }
    }
}