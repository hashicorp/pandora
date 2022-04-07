using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2021_09_01.Registries;

internal class Definition : ResourceDefinition
{
    public string Name => "Registries";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new GetPrivateLinkResourceOperation(),
        new ImportImageOperation(),
        new ListOperation(),
        new ListByResourceGroupOperation(),
        new ListCredentialsOperation(),
        new ListPrivateLinkResourcesOperation(),
        new ListUsagesOperation(),
        new RegenerateCredentialOperation(),
        new UpdateOperation(),
    };
}
