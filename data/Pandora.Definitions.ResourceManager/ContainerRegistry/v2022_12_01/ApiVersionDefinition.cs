using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2022_12_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2022-12-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new Operation.Definition(),
        new PrivateEndpointConnections.Definition(),
        new Registries.Definition(),
        new Replications.Definition(),
        new ScopeMaps.Definition(),
        new Tokens.Definition(),
        new WebHooks.Definition(),
    };
}
