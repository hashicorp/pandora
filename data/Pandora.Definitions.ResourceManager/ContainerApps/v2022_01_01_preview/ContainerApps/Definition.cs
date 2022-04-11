using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_01_01_preview.ContainerApps;

internal class Definition : ResourceDefinition
{
    public string Name => "ContainerApps";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByResourceGroupOperation(),
        new ListBySubscriptionOperation(),
        new ListCustomHostNameAnalysisOperation(),
        new ListSecretsOperation(),
        new UpdateOperation(),
    };
}
