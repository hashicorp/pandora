using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Databricks.v2023_02_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2023-02-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new DELETE.Definition(),
        new OutboundNetworkDependenciesEndpoints.Definition(),
        new PUT.Definition(),
        new PrivateEndpointConnections.Definition(),
        new PrivateLinkResources.Definition(),
        new VNetPeering.Definition(),
        new Workspaces.Definition(),
    };
}
