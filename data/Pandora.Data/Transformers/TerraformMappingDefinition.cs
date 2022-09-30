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
        var modelToModels = new List<Models.TerraformModelToModelMappingDefinition>();
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

            if (item is DirectAssignmentMapping direct)
            {
                var schemaModelName = direct.FromSchemaModelName.RemoveModelSuffixFromTypeName();
                var sdkModelName = direct.ToSdkModelName.RemoveModelSuffixFromTypeName();
                fields.Add(new Models.TerraformFieldMappingDefinition
                {
                    Type = Models.TerraformFieldMappingType.DirectAssignment,
                    DirectAssignment = new Models.TerraformFieldMappingDirectAssignmentDefinition
                    {
                        SchemaModelName = schemaModelName,
                        SchemaFieldName = direct.FromSchemaPath,

                        SdkModelName = sdkModelName,
                        SdkFieldName = direct.ToSdkFieldPath,
                    },
                });
                modelToModels.Add(new Models.TerraformModelToModelMappingDefinition
                {
                    SchemaModelName = schemaModelName,
                    SdkModelName = sdkModelName,
                });
                continue;
            }

            if (item is ModelToModelMapping modelToModel)
            {
                var schemaModelName = modelToModel.SchemaModelName.RemoveModelSuffixFromTypeName();
                var sdkModelName = modelToModel.SdkModelName.RemoveModelSuffixFromTypeName();

                fields.Add(new Models.TerraformFieldMappingDefinition
                {
                    Type = Models.TerraformFieldMappingType.ModelToModel,
                    ModelToModel = new Models.TerraformFieldMappingModelToModelDefinition
                    {
                        SchemaModelName = schemaModelName,

                        SdkModelName = sdkModelName,
                        SdkFieldName = modelToModel.SdkFieldPath,
                    },
                });
                modelToModels.Add(new Models.TerraformModelToModelMappingDefinition
                {
                    SchemaModelName = schemaModelName,
                    SdkModelName = sdkModelName,
                });
                continue;
            }

            // TODO: Manual etc

            throw new NotSupportedException($"unsupported mapping type {item.GetType().Name}");
        }

        modelToModels = modelToModels.DistinctBy(m => string.Format($"{m.SchemaModelName}-{m.SdkModelName}")).ToList();
        return new Models.TerraformMappingDefinition
        {
            Fields = fields.ToList(),
            ModelToModel = modelToModels,
            ResourceIds = resourceIds.ToList(),
        };
    }
}