using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.HybridCompute.v2022_03_10;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2022-03-10";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new MachineExtensions.Definition(),
        new MachineExtensionsUpgrade.Definition(),
        new Machines.Definition(),
        new PrivateEndpointConnections.Definition(),
        new PrivateLinkResources.Definition(),
        new PrivateLinkScopes.Definition(),
    };
}
