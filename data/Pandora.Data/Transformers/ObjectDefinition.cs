using System;
using Pandora.Data.Helpers;
using Pandora.Data.Models;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Data.Transformers;

public static class ObjectDefinition
{
    public static Models.ObjectDefinition Map(Type input)
    {
        if (input == null)
        {
            throw new NotSupportedException("cannot map a null type");
        }

        // if it's a nullable type (e.g. bool?) it's actually Nullable<bool> - pull out and map the actual type
        if (input.IsGenericType && input.GetGenericTypeDefinition() == typeof(Nullable<>))
        {
            var actualType = input.GenericTypeArguments[0];
            return Map(actualType);
        }

        if (input.IsNativeType())
        {
            return new Models.ObjectDefinition
            {
                Type = MapBuiltInObjectType(input)
            };
        }

        if (input.IsPandoraCustomType())
        {
            return new Models.ObjectDefinition
            {
                Type = MapPandoraCustomType(input)
            };
        }

        if (input.IsAGenericCsv())
        {
            var valueType = input.GenericCsvElement();
            var nestedItem = Map(valueType);
            return new Models.ObjectDefinition
            {
                Type = ObjectType.Csv,
                NestedItem = nestedItem,
            };
        }

        if (input.IsAGenericDictionary())
        {
            // at this time we only support keys which are strings, so we're only concerned with the Value Type here
            var valueType = input.GenericDictionaryValueElement();
            var nestedItem = Map(valueType);
            return new Models.ObjectDefinition
            {
                Type = ObjectType.Dictionary,
                NestedItem = nestedItem,
            };
        }

        if (input.IsAGenericList())
        {
            var valueType = input.GenericListElement();
            var nestedItem = Map(valueType);
            return new Models.ObjectDefinition
            {
                Type = ObjectType.List,
                NestedItem = nestedItem,
            };
        }

        var responseObjectName = input.Name;
        responseObjectName = responseObjectName.RemoveSuffixFromTypeName();
        return new Models.ObjectDefinition
        {
            Type = ObjectType.Reference,
            ReferenceName = responseObjectName,
        };
    }

    private static ObjectType MapBuiltInObjectType(Type input)
    {
        if (input == typeof(bool))
        {
            return ObjectType.Boolean;
        }
        if (input == typeof(DateTime))
        {
            return ObjectType.DateTime;
        }
        if (input == typeof(float))
        {
            return ObjectType.Float;
        }
        if (input == typeof(int))
        {
            return ObjectType.Integer;
        }
        if (input == typeof(object))
        {
            return ObjectType.RawObject;
        }
        if (input == typeof(string))
        {
            return ObjectType.String;
        }

        throw new NotSupportedException($"built-in type {input.FullName} is not mapped");
    }

    private static ObjectType MapPandoraCustomType(Type input)
    {
        if (input == typeof(EdgeZone))
        {
            return ObjectType.EdgeZone;
        }
        if (input == typeof(Location))
        {
            return ObjectType.Location;
        }
        if (input == typeof(RawFile))
        {
            return ObjectType.RawFile;
        }
        if (input == typeof(SystemAssignedIdentity))
        {
            return ObjectType.SystemAssignedIdentity;
        }
        if (input == typeof(SystemAndUserAssignedIdentityList))
        {
            return ObjectType.SystemAndUserAssignedIdentityList;
        }
        if (input == typeof(SystemAndUserAssignedIdentityMap))
        {
            return ObjectType.SystemAndUserAssignedIdentityMap;
        }
        if (input == typeof(LegacySystemAndUserAssignedIdentityList))
        {
            return ObjectType.LegacySystemAndUserAssignedIdentityList;
        }
        if (input == typeof(LegacySystemAndUserAssignedIdentityMap))
        {
            return ObjectType.LegacySystemAndUserAssignedIdentityMap;
        }
        if (input == typeof(SystemOrUserAssignedIdentityList))
        {
            return ObjectType.SystemOrUserAssignedIdentityList;
        }
        if (input == typeof(SystemOrUserAssignedIdentityMap))
        {
            return ObjectType.SystemOrUserAssignedIdentityMap;
        }
        if (input == typeof(UserAssignedIdentityList))
        {
            return ObjectType.UserAssignedIdentityList;
        }
        if (input == typeof(UserAssignedIdentityMap))
        {
            return ObjectType.UserAssignedIdentityMap;
        }
        if (input == typeof(Tags))
        {
            return ObjectType.Tags;
        }
        if (input == typeof(SystemData))
        {
            return ObjectType.SystemData;
        }
        if (input == typeof(Zones))
        {
            return ObjectType.Zones;
        }
        if (input == typeof(Zone))
        {
            return ObjectType.Zone;
        }

            throw new NotSupportedException($"Pandora custom type {input.FullName} is not mapped");
    }
}