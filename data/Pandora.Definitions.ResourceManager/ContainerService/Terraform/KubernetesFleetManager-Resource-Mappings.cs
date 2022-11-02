using System.Collections.Generic;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Mappings;
using Pandora.Definitions.ResourceManager.ContainerService.v2022_09_02_preview.Fleets;

namespace Pandora.Definitions.ResourceManager.ContainerService.Terraform;

public class KubernetesFleetManagerResourceMappings : TerraformMappingDefinition
{
    public List<MappingType> Mappings => new List<MappingType>
    {
        Mapping.FromSchema<KubernetesFleetManagerResourceSchema>(s => s.Name).ToResourceIdSegmentNamed("fleetName"),
        Mapping.FromSchema<KubernetesFleetManagerResourceSchema>(s => s.ResourceGroupName).ToResourceIdSegmentNamed("resourceGroupName"),

        Mapping.FromSchema<KubernetesFleetManagerResourceFleetHubProfileSchema>(s => s.DnsPrefix).ToSdkField<FleetHubProfileModel>(m => m.DnsPrefix).Direct(),
        Mapping.FromSchema<KubernetesFleetManagerResourceFleetHubProfileSchema>(s => s.Fqdn).ToSdkField<FleetHubProfileModel>(m => m.Fqdn).Direct(),
        Mapping.FromSchema<KubernetesFleetManagerResourceFleetHubProfileSchema>(s => s.KubernetesVersion).ToSdkField<FleetHubProfileModel>(m => m.KubernetesVersion).Direct(),
        Mapping.FromSchema<KubernetesFleetManagerResourceSchema>(s => s.HubProfile).ToSdkField<FleetPropertiesModel>(m => m.HubProfile).Direct(),
        Mapping.FromSchema<KubernetesFleetManagerResourceSchema>(s => s.Location).ToSdkField<FleetModel>(m => m.Location).Direct(),
        Mapping.FromSchema<KubernetesFleetManagerResourceSchema>(s => s.Tags).ToSdkField<FleetModel>(m => m.Tags).Direct(),
        Mapping.FromSchemaModel<KubernetesFleetManagerResourceFleetHubProfileSchema>().ToSdkField<FleetPropertiesModel>(m => m.HubProfile).ModelToModel(),
        Mapping.FromSchemaModel<KubernetesFleetManagerResourceSchema>().ToSdkField<FleetModel>(m => m.Properties).ModelToModel(),
    };
}
