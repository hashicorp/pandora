using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Relay.v2021_11_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2021-11-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new HybridConnections.Definition(),
        new Namespaces.Definition(),
        new NamespacesPrivateEndpointConnections.Definition(),
        new NamespacesPrivateLinkResources.Definition(),
        new WCFRelays.Definition(),
    };
}
