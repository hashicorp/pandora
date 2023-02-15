using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.ContainerService.v2023_01_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2023-01-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new AgentPools.Definition(),
        new MaintenanceConfigurations.Definition(),
        new ManagedClusters.Definition(),
        new PrivateEndpointConnections.Definition(),
        new PrivateLinkResources.Definition(),
        new ResolvePrivateLinkServiceId.Definition(),
        new Snapshots.Definition(),
    };
}
