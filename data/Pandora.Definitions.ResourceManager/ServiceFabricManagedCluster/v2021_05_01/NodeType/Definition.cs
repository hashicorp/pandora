using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.ServiceFabricManagedCluster.v2021_05_01.NodeType
{
    internal class Definition : ResourceDefinition
    {
        public string Name => "NodeType";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new CreateOrUpdateOperation(),
            new DeleteOperation(),
            new DeleteNodeOperation(),
            new GetOperation(),
            new ListByManagedClustersOperation(),
            new ReimageOperation(),
            new RestartOperation(),
            new UpdateOperation(),
        };
    }
}
