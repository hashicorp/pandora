using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.KubernetesConfiguration.v2021_09_01.OperationsInACluster;

internal class Definition : ResourceDefinition
{
    public string Name => "OperationsInACluster";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new OperationStatusListOperation(),
    };
}
