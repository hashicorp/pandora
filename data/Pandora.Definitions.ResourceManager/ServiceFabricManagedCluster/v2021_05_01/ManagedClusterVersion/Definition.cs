using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.ServiceFabricManagedCluster.v2021_05_01.ManagedClusterVersion
{
    internal class Definition : ApiDefinition
    {
        public string Name => "ManagedClusterVersion";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new GetOperation(),
            new GetByEnvironmentOperation(),
            new ListOperation(),
            new ListByEnvironmentOperation(),
        };
    }
}
