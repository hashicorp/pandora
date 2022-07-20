using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Kusto.v2021_08_27;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2021-08-27";
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

    public IEnumerable<TerraformResourceDefinition> TerraformResources => new List<TerraformResourceDefinition>
    {
    };
}
