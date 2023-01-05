using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.ContainerService.v2022_11_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2022-11-01";
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
