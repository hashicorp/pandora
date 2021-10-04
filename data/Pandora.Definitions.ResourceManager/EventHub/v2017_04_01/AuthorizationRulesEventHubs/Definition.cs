using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2017_04_01.AuthorizationRulesEventHubs
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "28e60e3f539b44b60e7b4d6fa2cf4476519bcf93" 

        public string ApiVersion => "2017-04-01";
        public string Name => "AuthorizationRulesEventHubs";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new EventHubsCreateOrUpdateAuthorizationRuleOperation(),
            new EventHubsListAuthorizationRulesOperation(),
            new EventHubsListKeysOperation(),
            new EventHubsRegenerateKeysOperation(),
        };
    }
}
