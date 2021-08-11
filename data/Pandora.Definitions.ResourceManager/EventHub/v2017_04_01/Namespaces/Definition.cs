using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2017_04_01.Namespaces
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "fbb7ba76937668739778ac2272b9a607ea0511fc" 

        public string ApiVersion => "2017-04-01";
        public string Name => "Namespaces";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new CreateOrUpdateOperation(),
            new DeleteOperation(),
            new GetOperation(),
            new ListOperation(),
            new ListByResourceGroupOperation(),
            new UpdateOperation(),
        };
    }
}
