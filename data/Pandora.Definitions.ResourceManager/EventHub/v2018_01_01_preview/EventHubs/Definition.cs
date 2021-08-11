using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.EventHubs
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "fbb7ba76937668739778ac2272b9a607ea0511fc" 

        public string ApiVersion => "2018-01-01-preview";
        public string Name => "EventHubs";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new CreateOrUpdateOperation(),
            new DeleteOperation(),
            new GetOperation(),
            new ListByNamespaceOperation(),
        };
    }
}
