using System;
using Pandora.Data.Helpers;

namespace Pandora.Data.Transformers
{
    public static class ObjectDefinition
    {
        public static Models.ObjectDefinition? Map(Type input)
        {
            // TODO: tests and support for built-in types and lists etc
            var responseObjectName = input.Name;
            responseObjectName = RemoveSuffixFromTypeName(responseObjectName);
            
            return new Models.ObjectDefinition
            {
                Type = Models.ObjectType.Reference,
                ReferenceName = responseObjectName,
            };
        }

        private static string? RemoveSuffixFromTypeName(string? input)
        {
            if (input == null)
            {
                return null;
            }

            input = input.TrimSuffix("Constant");
            input = input.TrimSuffix("Model");
            return input;
        }
    }
}