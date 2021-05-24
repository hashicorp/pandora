using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2017_04_01.AuthorizationRulesEventHubs
{
    internal class Definition : ApiDefinition
    {
        public string ApiVersion => "v2017-04-01";
        public string Name => "AuthorizationRulesEventHubs";
        public IEnumerable<ApiOperation> Operations => new List<ApiOperation>
        {
            new EventHubsCreateOrUpdateAuthorizationRule(),
            new EventHubsListAuthorizationRules(),
            new EventHubsListKeys(),
            new EventHubsRegenerateKeys(),
        };
    }
}