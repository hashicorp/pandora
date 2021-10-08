using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Relay.v2017_04_01.Namespaces
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "b28a542b3eb4f2f4f384b14b635d0a835df818cd" 

        public string ApiVersion => "2017-04-01";
        public string Name => "Namespaces";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new CheckNameAvailabilityOperation(),
            new CreateOrUpdateOperation(),
            new CreateOrUpdateAuthorizationRuleOperation(),
            new DeleteOperation(),
            new DeleteAuthorizationRuleOperation(),
            new GetOperation(),
            new GetAuthorizationRuleOperation(),
            new ListOperation(),
            new ListAuthorizationRulesOperation(),
            new ListByResourceGroupOperation(),
            new ListKeysOperation(),
            new RegenerateKeysOperation(),
            new UpdateOperation(),
        };
    }
}
