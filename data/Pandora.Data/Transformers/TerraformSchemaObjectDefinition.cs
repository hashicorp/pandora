using System;
using Pandora.Data.Helpers;
using Pandora.Data.Models;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Data.Transformers;

public static class TerraformSchemaObjectDefinition
{
    public static Models.TerraformSchemaObjectDefinition Map(Type input)
    {
        // NOTE: this isn't directly tested because it's tested via `TerraformSchemaFieldDefinition`
        // we should look to add specific acctests for this though
        // TODO: add tests specifically for this method
        // TODO: support for Sets

        if (input.IsAGenericDictionary())
        {
            var listElement = input.GenericDictionaryValueElement();
            var nestedItem = Map(listElement);
            return new Models.TerraformSchemaObjectDefinition
            {
                Type = TerraformSchemaFieldType.Dictionary,
                NestedObject = nestedItem,
            };
        }

        if (input.IsAGenericList())
        {
            var listElement = input.GenericListElement();
            var nestedItem = Map(listElement);
            return new Models.TerraformSchemaObjectDefinition
            {
                Type = TerraformSchemaFieldType.List,
                NestedObject = nestedItem,
            };
        }

        if (input.IsNativeType())
        {
            return new Models.TerraformSchemaObjectDefinition
            {
                Type = MapNativeType(input),
            };
        }

        if (input.IsPandoraCommonSchemaType())
        {
            return new Models.TerraformSchemaObjectDefinition
            {
                Type = MapPandoraCommonSchema(input),
            };
        }

        if (input.IsClass)
        {
            return new Models.TerraformSchemaObjectDefinition
            {
                Type = TerraformSchemaFieldType.Reference,
                ReferenceName = input.Name,
            };
        }

        throw new NotSupportedException($"schema field type {input.Name} is not mapped");
    }

    private static TerraformSchemaFieldType MapNativeType(Type input)
    {
        if (input == typeof(bool))
        {
            return TerraformSchemaFieldType.Boolean;
        }
        if (input == typeof(DateTime))
        {
            return TerraformSchemaFieldType.DateTime;
        }
        if (input == typeof(float))
        {
            return TerraformSchemaFieldType.Float;
        }
        if (input == typeof(int))
        {
            return TerraformSchemaFieldType.Integer;
        }
        if (input == typeof(string))
        {
            return TerraformSchemaFieldType.String;
        }

        // NOTE: we intentionally don't support Object because how would we express it in the Schema?

        throw new NotSupportedException($"native type {input.Name} is not mapped");
    }

    private static TerraformSchemaFieldType MapPandoraCommonSchema(Type input)
    {
        if (input == typeof(EdgeZoneSingle))
        {
            return TerraformSchemaFieldType.EdgeZone;
        }
        if (input == typeof(Location))
        {
            return TerraformSchemaFieldType.Location;
        }
        if (input == typeof(ResourceGroupName))
        {
            return TerraformSchemaFieldType.ResourceGroup;
        }
        if (input == typeof(Tags))
        {
            return TerraformSchemaFieldType.Tags;
        }
        if (input == typeof(SystemAssignedIdentity))
        {
            return TerraformSchemaFieldType.IdentitySystemAssigned;
        }
        if (input == typeof(SystemAndUserAssignedIdentity))
        {
            return TerraformSchemaFieldType.IdentitySystemAndUserAssigned;
        }
        if (input == typeof(SystemOrUserAssignedIdentity))
        {
            return TerraformSchemaFieldType.IdentitySystemOrUserAssigned;
        }
        if (input == typeof(UserAssignedIdentity))
        {
            return TerraformSchemaFieldType.IdentityUserAssigned;
        }
        if (input == typeof(ZoneSingle))
        {
            return TerraformSchemaFieldType.Zone;
        }
        if (input == typeof(ZonesMultiple))
        {
            return TerraformSchemaFieldType.Zones;
        }

        // RawFile and SystemData aren't supported in the Schema because how would we output them?
        throw new NotSupportedException($"pandora custom type {input.Name} is not mapped");
    }
}