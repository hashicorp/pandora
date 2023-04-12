using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.PostgreSqlHSC.v2022_11_08;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2022-11-08";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new ClusterOperations.Definition(),
        new Clusters.Definition(),
        new Configurations.Definition(),
        new FirewallRules.Definition(),
        new PrivateEndpointConnections.Definition(),
        new PrivateLinkResources.Definition(),
        new Roles.Definition(),
        new Servers.Definition(),
    };
}
