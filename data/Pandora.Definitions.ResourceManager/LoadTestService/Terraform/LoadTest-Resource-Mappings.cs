using System.Collections.Generic;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Mappings;
using Pandora.Definitions.ResourceManager.LoadTestService.v2021_12_01_preview.LoadTests;

namespace Pandora.Definitions.ResourceManager.LoadTestService.Terraform;

public class LoadTestResourceMappings : TerraformMappingDefinition
{
    public List<MappingType> Mappings => new List<MappingType>
    {
        Mapping.FromSchema<LoadTestResourceSchema>(s => s.Name).ToResourceIdSegmentNamed("loadTestName"),
        Mapping.FromSchema<LoadTestResourceSchema>(s => s.ResourceGroupName).ToResourceIdSegmentNamed("resourceGroupName"),

        Mapping.FromSchema<LoadTestResourceSchema>(s => s.DataPlaneURI).ToSdkField<LoadTestPropertiesModel>(m => m.DataPlaneURI).Direct(),
        Mapping.FromSchema<LoadTestResourceSchema>(s => s.Description).ToSdkField<LoadTestPropertiesModel>(m => m.Description).Direct(),
        Mapping.FromSchema<LoadTestResourceSchema>(s => s.Description).ToSdkField<LoadTestResourcePatchRequestBodyPropertiesModel>(m => m.Description).Direct(),
        Mapping.FromSchema<LoadTestResourceSchema>(s => s.Identity).ToSdkField<LoadTestResourceModel>(m => m.Identity).Direct(),
        Mapping.FromSchema<LoadTestResourceSchema>(s => s.Identity).ToSdkField<LoadTestResourcePatchRequestBodyModel>(m => m.Identity).Direct(),
        Mapping.FromSchema<LoadTestResourceSchema>(s => s.Location).ToSdkField<LoadTestResourceModel>(m => m.Location).Direct(),
        Mapping.FromSchema<LoadTestResourceSchema>(s => s.Tags).ToSdkField<LoadTestResourceModel>(m => m.Tags).Direct(),
        Mapping.FromSchema<LoadTestResourceSchema>(s => s.Tags).ToSdkField<LoadTestResourcePatchRequestBodyModel>(m => m.Tags).Direct(),
        Mapping.FromSchemaModel<LoadTestResourceSchema>().ToSdkField<LoadTestResourceModel>(m => m.Properties).ModelToModel(),
        Mapping.FromSchemaModel<LoadTestResourceSchema>().ToSdkField<LoadTestResourcePatchRequestBodyModel>(m => m.Properties).ModelToModel(),
    };
}
