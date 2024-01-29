// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Mappings;
using Pandora.Definitions.ResourceManager.DevCenter.v2023_04_01.Projects;

namespace Pandora.Definitions.ResourceManager.DevCenter.Terraform;

public class DevCenterProjectResourceMappings : TerraformMappingDefinition
{
    public List<MappingType> Mappings => new List<MappingType>
    {
        Mapping.FromSchema<DevCenterProjectResourceSchema>(s => s.Name).ToResourceIdSegmentNamed("projectName"),
        Mapping.FromSchema<DevCenterProjectResourceSchema>(s => s.ResourceGroupName).ToResourceIdSegmentNamed("resourceGroupName"),

        Mapping.FromSchema<DevCenterProjectResourceSchema>(s => s.Description).ToSdkField<ProjectPropertiesModel>(m => m.Description).Direct(),
        Mapping.FromSchema<DevCenterProjectResourceSchema>(s => s.DevCenterId).ToSdkField<ProjectPropertiesModel>(m => m.DevCenterId).Direct(),
        Mapping.FromSchema<DevCenterProjectResourceSchema>(s => s.DevCenterUri).ToSdkField<ProjectPropertiesModel>(m => m.DevCenterUri).Direct(),
        Mapping.FromSchema<DevCenterProjectResourceSchema>(s => s.Location).ToSdkField<ProjectModel>(m => m.Location).Direct(),
        Mapping.FromSchema<DevCenterProjectResourceSchema>(s => s.MaximumDevBoxesPerUser).ToSdkField<ProjectPropertiesModel>(m => m.MaxDevBoxesPerUser).Direct(),
        Mapping.FromSchema<DevCenterProjectResourceSchema>(s => s.MaximumDevBoxesPerUser).ToSdkField<ProjectUpdatePropertiesModel>(m => m.MaxDevBoxesPerUser).Direct(),
        Mapping.FromSchema<DevCenterProjectResourceSchema>(s => s.Tags).ToSdkField<ProjectModel>(m => m.Tags).Direct(),
        Mapping.FromSchema<DevCenterProjectResourceSchema>(s => s.Tags).ToSdkField<ProjectUpdateModel>(m => m.Tags).Direct(),
        Mapping.FromSchemaModel<DevCenterProjectResourceSchema>().ToSdkField<ProjectModel>(m => m.Properties).ModelToModel(),
        Mapping.FromSchemaModel<DevCenterProjectResourceSchema>().ToSdkField<ProjectUpdateModel>(m => m.Properties).ModelToModel(),
    };
}
