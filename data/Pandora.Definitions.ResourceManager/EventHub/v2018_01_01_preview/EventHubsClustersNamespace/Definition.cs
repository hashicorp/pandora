using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.EventHubsClustersNamespace
{
    internal class Definition : ApiDefinition
    {
        public string Name => "EventHubsClustersNamespace";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new ClustersListNamespacesOperation(),
        };
    }
}
