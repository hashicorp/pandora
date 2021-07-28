using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Relay.v2017_04_01.Namespaces
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "552b277f9f8d2057a94dfc9c3e09c0d877c0ea30" 

        public string ApiVersion => "2017-04-01";
        public string Name => "Namespaces";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new CheckNameAvailability(),
            new CreateOrUpdate(),
            new CreateOrUpdateAuthorizationRule(),
            new Delete(),
            new DeleteAuthorizationRule(),
            new Get(),
            new GetAuthorizationRule(),
            new List(),
            new ListAuthorizationRules(),
            new ListByResourceGroup(),
            new ListKeys(),
            new RegenerateKeys(),
            new Update(),
        };
    }
}
