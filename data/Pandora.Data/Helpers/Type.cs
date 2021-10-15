using System;
using System.Collections.Generic;
using System.Reflection;
using Pandora.Data.Transformers;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Data.Helpers
{
    public static class TypeExtensions
    {
        /// <summary>
        /// GetActualType returns the Actual Type if this is a Csv/Dictionary/List - or input otherwise
        /// for example `List<Model>` will return the Type `Model`. This'll be null if a built-in, custom
        /// or Enum type is provided.
        /// </summary>
        internal static Type? GetActualType(this Type input, bool allowEnums)
        {
            if (!allowEnums && input.IsEnum)
            {
                return null;
            }

            if (input.IsNativeType() || input.IsPandoraCustomType())
            {
                return null;
            }

            // if it's nullable pull that out
            if (Nullable.GetUnderlyingType(input) != null)
            {
                var genericArgs = input.GetGenericArguments();
                var element = genericArgs[0];
                return GetActualType(element, allowEnums);
            }

            if (input.IsAGenericCsv())
            {
                var valueType = input.GenericCsvElement();
                return GetActualType(valueType, allowEnums);
            }
            if (input.IsAGenericDictionary())
            {
                var valueType = input.GenericDictionaryValueElement();
                return GetActualType(valueType, allowEnums);
            }
            if (input.IsAGenericList())
            {
                var valueType = input.GenericListElement();
                return GetActualType(valueType, allowEnums);
            }

            return input;
        }
        
        public static bool IsNativeType(this Type input)
        {
            var nativeTypes = new List<Type>
            {
                typeof(bool),
                typeof(DateTime),
                typeof(float),
                typeof(int),
                typeof(object),
                typeof(string),
            };
            return nativeTypes.Contains(input);
        }
        
        public static bool IsPandoraCustomType(this Type input)
        {
            var customTypes = new List<Type>
            {
                typeof(Location),
                typeof(RawFile),
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

        internal static bool IsAGenericCsv(this Type input)
        {
            return input.IsGenericType && input.GetGenericTypeDefinition() == typeof(Csv<>);
        }

        internal static Type GenericCsvElement(this Type input)
        {
            if (!input.IsAGenericCsv())
            {
                throw new NotSupportedException($"unsupported Csv Type {input.Name}");
            }

            return input.GetGenericArguments()[0];
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