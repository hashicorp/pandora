using System;
using Pandora.Data.Helpers;

namespace Pandora.Data.Models
{
    public class ObjectDefinition
    {
        public ObjectType Type { get; set; }

        public string? ReferenceName { get; set; }

        public static ObjectDefinition? Map(Type input)
        {
            var responseObjectName = input.Name;
            responseObjectName = RemoveSuffixFromTypeName(responseObjectName);
            
            return new ObjectDefinition
            {
                Type = ObjectType.Reference,
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