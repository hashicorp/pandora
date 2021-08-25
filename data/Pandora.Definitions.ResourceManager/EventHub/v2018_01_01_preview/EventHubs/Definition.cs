using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.EventHubs
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "44017a20d8c022217b31e15643595fc7aff87926" 

        public string ApiVersion => "2018-01-01-preview";
        public string Name => "EventHubs";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new CreateOrUpdateOperation(),
            new DeleteOperation(),
            new DeleteAuthorizationRuleOperation(),
            new GetOperation(),
            new GetAuthorizationRuleOperation(),
            new ListByNamespaceOperation(),
        };
    }
}
