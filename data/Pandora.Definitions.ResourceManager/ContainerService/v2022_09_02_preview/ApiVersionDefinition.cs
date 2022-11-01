using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.ContainerService.v2022_09_02_preview;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2022-09-02-preview";
    public bool Preview => true;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new AgentPools.Definition(),
        new FleetMembers.Definition(),
        new Fleets.Definition(),
        new MaintenanceConfigurations.Definition(),
        new ManagedClusterSnapshots.Definition(),
        new ManagedClusters.Definition(),
        new PrivateEndpointConnections.Definition(),
        new PrivateLinkResources.Definition(),
        new ResolvePrivateLinkServiceId.Definition(),
        new Snapshots.Definition(),
        new TrustedAccess.Definition(),
    };
}
