using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.EventHubsClusters
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "b9aa58703085cdccefe4b8726b0757c00adc9072" 

        public string ApiVersion => "2018-01-01-preview";
        public string Name => "EventHubsClusters";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new ClustersCreateOrUpdateOperation(),
            new ClustersDeleteOperation(),
            new ClustersGetOperation(),
            new ClustersListByResourceGroupOperation(),
            new ClustersUpdateOperation(),
        };
    }
}
