// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Mappings;
using Pandora.Definitions.ResourceManager.DevCenter.v2023_04_01.DevCenters;

namespace Pandora.Definitions.ResourceManager.DevCenter.Terraform;

public class DevCenterResourceMappings : TerraformMappingDefinition
{
    public List<MappingType> Mappings => new List<MappingType>
    {
        Mapping.FromSchema<DevCenterResourceSchema>(s => s.Name).ToResourceIdSegmentNamed("devCenterName"),
        Mapping.FromSchema<DevCenterResourceSchema>(s => s.ResourceGroupName).ToResourceIdSegmentNamed("resourceGroupName"),

        Mapping.FromSchema<DevCenterResourceSchema>(s => s.DevCenterUri).ToSdkField<DevCenterPropertiesModel>(m => m.DevCenterUri).Direct(),
        Mapping.FromSchema<DevCenterResourceSchema>(s => s.Identity).ToSdkField<DevCenterModel>(m => m.Identity).Direct(),
        Mapping.FromSchema<DevCenterResourceSchema>(s => s.Location).ToSdkField<DevCenterModel>(m => m.Location).Direct(),
        Mapping.FromSchema<DevCenterResourceSchema>(s => s.Tags).ToSdkField<DevCenterModel>(m => m.Tags).Direct(),
        Mapping.FromSchemaModel<DevCenterResourceSchema>().ToSdkField<DevCenterModel>(m => m.Properties).ModelToModel(),
    };
}
