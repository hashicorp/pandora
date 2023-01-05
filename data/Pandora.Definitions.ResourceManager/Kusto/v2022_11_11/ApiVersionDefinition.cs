using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Kusto.v2022_11_11;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2022-11-11";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new AttachedDatabaseConfigurations.Definition(),
        new ClusterPrincipalAssignments.Definition(),
        new Clusters.Definition(),
        new DataConnections.Definition(),
        new DatabasePrincipalAssignments.Definition(),
        new Databases.Definition(),
        new Kusto.Definition(),
        new ManagedPrivateEndpoints.Definition(),
        new OutboundNetworkDependenciesEndpoints.Definition(),
        new PrivateEndpointConnections.Definition(),
        new PrivateLinkResources.Definition(),
        new Scripts.Definition(),
    };
}
