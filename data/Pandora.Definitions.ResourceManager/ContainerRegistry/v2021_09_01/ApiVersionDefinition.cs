using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2021_09_01;
public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2021-09-01";
    public bool Preview => false;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new Operation.Definition(),
        new PrivateEndpointConnections.Definition(),
        new Registries.Definition(),
        new Replications.Definition(),
        new Webhooks.Definition(),
    };
}
