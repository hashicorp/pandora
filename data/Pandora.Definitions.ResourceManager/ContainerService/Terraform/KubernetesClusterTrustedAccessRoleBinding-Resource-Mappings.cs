// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Mappings;
using Pandora.Definitions.ResourceManager.ContainerService.v2023_03_02_preview.TrustedAccess;

namespace Pandora.Definitions.ResourceManager.ContainerService.Terraform;

public class KubernetesClusterTrustedAccessRoleBindingResourceMappings : TerraformMappingDefinition
{
    public List<MappingType> Mappings => new List<MappingType>
    {
        Mapping.FromSchema<KubernetesClusterTrustedAccessRoleBindingResourceSchema>(s => s.KubernetesClusterId).ToCommonIdSegmentNamed("managedClusterName"),
        Mapping.FromSchema<KubernetesClusterTrustedAccessRoleBindingResourceSchema>(s => s.KubernetesClusterId).ToCommonIdSegmentNamed("resourceGroupName"),
        Mapping.FromSchema<KubernetesClusterTrustedAccessRoleBindingResourceSchema>(s => s.Name).ToResourceIdSegmentNamed("trustedAccessRoleBindingName"),

        Mapping.FromSchema<KubernetesClusterTrustedAccessRoleBindingResourceSchema>(s => s.Roles).ToSdkField<TrustedAccessRoleBindingPropertiesModel>(m => m.Roles).Direct(),
        Mapping.FromSchema<KubernetesClusterTrustedAccessRoleBindingResourceSchema>(s => s.SourceResourceId).ToSdkField<TrustedAccessRoleBindingPropertiesModel>(m => m.SourceResourceId).Direct(),
        Mapping.FromSchemaModel<KubernetesClusterTrustedAccessRoleBindingResourceSchema>().ToSdkField<TrustedAccessRoleBindingModel>(m => m.Properties).ModelToModel(),
    };
}
