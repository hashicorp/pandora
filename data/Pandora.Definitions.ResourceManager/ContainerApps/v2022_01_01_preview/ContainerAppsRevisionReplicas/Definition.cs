using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_01_01_preview.ContainerAppsRevisionReplicas;

internal class Definition : ResourceDefinition
{
    public string Name => "ContainerAppsRevisionReplicas";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetReplicaOperation(),
        new ListReplicasOperation(),
    };
}
