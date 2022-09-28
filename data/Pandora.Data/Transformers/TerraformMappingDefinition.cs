using System;
using System.Collections.Generic;
using System.Linq;
using Pandora.Data.Helpers;
using Pandora.Definitions.Mappings;

namespace Pandora.Data.Transformers;

public static class TerraformMappingDefinition
{
    public static Models.TerraformMappingDefinition Map(Definitions.Interfaces.TerraformMappingDefinition input)
    {
        var fields = new List<Models.TerraformFieldMappingDefinition>();
        var resourceIds = new List<Models.TerraformResourceIDMappingDefinition>();

        foreach (var item in input.Mappings)
        {
            if (item is ResourceIdMapping resourceIdMapping)
            {
                resourceIds.Add(new Models.TerraformResourceIDMappingDefinition
                {
                    SegmentName = resourceIdMapping.SegmentName,
                    SchemaFieldName = resourceIdMapping.SchemaFieldName
                });
                continue;
            }

            if (item is DirectAssignmentMapping mapping)
            {
                fields.Add(new Models.TerraformFieldMappingDefinition
                {
                    Type = Models.TerraformFieldMappingType.DirectAssignment,
                    DirectAssignment = new Models.TerraformFieldMappingDirectAssignmentDefinition
                    {
                        SchemaModelName = mapping.FromSchemaModelName.RemoveModelSuffixFromTypeName(),
                        SchemaFieldName = mapping.FromSchemaPath,

                        SdkModelName = mapping.ToSdkModelName.RemoveModelSuffixFromTypeName(),
                        SdkFieldName = mapping.ToSdkFieldPath,
                    },
                });
                continue;
            }

            // TODO: Manual, ModelToModel etc

            throw new NotSupportedException($"unsupported mapping type {item.GetType().Name}");
        }

        return new Models.TerraformMappingDefinition
        {
            Fields = fields.ToList(),
            ResourceIds = resourceIds.ToList(),
        };
    }
}