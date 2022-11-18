using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.VMware.v2022_05_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2022-05-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new Addons.Definition(),
        new Authorizations.Definition(),
        new CloudLinks.Definition(),
        new Cluster.Definition(),
        new Clusters.Definition(),
        new DataStores.Definition(),
        new GlobalReachConnections.Definition(),
        new HcxEnterpriseSites.Definition(),
        new Locations.Definition(),
        new PlacementPolicies.Definition(),
        new PrivateClouds.Definition(),
        new Scripts.Definition(),
        new VirtualMachines.Definition(),
        new WorkloadNetworks.Definition(),
        new Zone.Definition(),
    };
}
