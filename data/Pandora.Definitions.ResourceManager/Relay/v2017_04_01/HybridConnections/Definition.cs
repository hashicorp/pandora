using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Relay.v2017_04_01.HybridConnections
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "b9aa58703085cdccefe4b8726b0757c00adc9072" 

        public string ApiVersion => "2017-04-01";
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
