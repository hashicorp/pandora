using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Relay.v2017_04_01.HybridConnections
{
    internal class Definition : ResourceDefinition
    {
        public string Name => "HybridConnections";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new CreateOrUpdateOperation(),
            new CreateOrUpdateAuthorizationRuleOperation(),
            new DeleteOperation(),
            new DeleteAuthorizationRuleOperation(),
            new GetOperation(),
            new GetAuthorizationRuleOperation(),
            new ListAuthorizationRulesOperation(),
            new ListByNamespaceOperation(),
            new ListKeysOperation(),
            new RegenerateKeysOperation(),
        };
    }
}
