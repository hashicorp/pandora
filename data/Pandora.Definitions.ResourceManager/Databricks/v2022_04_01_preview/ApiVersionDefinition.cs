using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Databricks.v2022_04_01_preview;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2022-04-01-preview";
    public bool Preview => true;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new AccessConnector.Definition(),
        new DELETE.Definition(),
        new OutboundNetworkDependenciesEndpoints.Definition(),
        new PUT.Definition(),
        new PrivateEndpointConnections.Definition(),
        new PrivateLinkResources.Definition(),
        new VNetPeering.Definition(),
        new Workspaces.Definition(),
    };
}
