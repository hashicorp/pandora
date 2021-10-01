using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2017_04_01.EventHubs
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "fd7603f9a8acb1decf94f7770a0bfe7b78df9b20" 

        public string ApiVersion => "2017-04-01";
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
