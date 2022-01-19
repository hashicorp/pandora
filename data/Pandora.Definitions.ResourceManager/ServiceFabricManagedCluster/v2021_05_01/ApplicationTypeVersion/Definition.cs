using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.ServiceFabricManagedCluster.v2021_05_01.ApplicationTypeVersion
{
    internal class Definition : ResourceDefinition
    {
        public string Name => "ApplicationTypeVersion";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new CreateOrUpdateOperation(),
            new DeleteOperation(),
            new GetOperation(),
            new ListByApplicationTypesOperation(),
            new UpdateOperation(),
        };
    }
}
