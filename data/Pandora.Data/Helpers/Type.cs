using System;
using Pandora.Data.Transformers;

namespace Pandora.Data.Helpers
{
    public static class TypeExtensions
    {
        /// <summary>
        /// GetActualType returns the Actual Type if this is a Csv/Dictionary/List - or input otherwise
        /// for example `List<Model>` will return the Type `Model`. This'll be null if a built-in, custom
        /// or Enum type is provided.
        /// </summary>
        internal static Type? GetActualType(this Type input)
        {
            if (input.IsEnum)
            {
                return null;
            }

            if (Transformers.Helpers.IsNativeType(input) || Transformers.Helpers.IsPandoraCustomType(input))
            {
                return null;
            }

            // if it's nullable pull that out
            if (Nullable.GetUnderlyingType(input) != null)
            {
                var genericArgs = input.GetGenericArguments();
                var element = genericArgs[0];
                return GetActualType(element);
            }

            if (input.IsAGenericCsv())
            {
                var valueType = input.GenericCsvElement();
                return GetActualType(valueType);
            }
            if (input.IsAGenericDictionary())
            {
                var valueType = input.GenericDictionaryValueElement();
                return GetActualType(valueType);
            }
            if (input.IsAGenericList())
            {
                var valueType = input.GenericListElement();
                return GetActualType(valueType);
            }

            return input;
        }
    }
}