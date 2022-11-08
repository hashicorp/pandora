using System.Collections.Generic;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Mappings;
using Pandora.Definitions.ResourceManager.ManagedIdentity.v2022_01_31_preview.ManagedIdentities;

namespace Pandora.Definitions.ResourceManager.ManagedIdentity.Terraform;

public class UserAssignedIdentityResourceMappings : TerraformMappingDefinition
{
    public List<MappingType> Mappings => new List<MappingType>
    {
        Mapping.FromSchema<UserAssignedIdentityResourceSchema>(s => s.Name).ToResourceIdSegmentNamed("resourceName"),
        Mapping.FromSchema<UserAssignedIdentityResourceSchema>(s => s.ResourceGroupName).ToResourceIdSegmentNamed("resourceGroupName"),

        Mapping.FromSchema<UserAssignedIdentityResourceSchema>(s => s.ClientId).ToSdkField<UserAssignedIdentityPropertiesModel>(m => m.ClientId).Direct(),
        Mapping.FromSchema<UserAssignedIdentityResourceSchema>(s => s.Location).ToSdkField<IdentityModel>(m => m.Location).Direct(),
        Mapping.FromSchema<UserAssignedIdentityResourceSchema>(s => s.PrincipalId).ToSdkField<UserAssignedIdentityPropertiesModel>(m => m.PrincipalId).Direct(),
        Mapping.FromSchema<UserAssignedIdentityResourceSchema>(s => s.Tags).ToSdkField<IdentityModel>(m => m.Tags).Direct(),
        Mapping.FromSchema<UserAssignedIdentityResourceSchema>(s => s.Tags).ToSdkField<IdentityUpdateModel>(m => m.Tags).Direct(),
        Mapping.FromSchema<UserAssignedIdentityResourceSchema>(s => s.TenantId).ToSdkField<UserAssignedIdentityPropertiesModel>(m => m.TenantId).Direct(),
        Mapping.FromSchemaModel<UserAssignedIdentityResourceSchema>().ToSdkField<IdentityModel>(m => m.Properties).ModelToModel(),
        Mapping.FromSchemaModel<UserAssignedIdentityResourceSchema>().ToSdkField<IdentityUpdateModel>(m => m.Properties).ModelToModel(),
    };
}
