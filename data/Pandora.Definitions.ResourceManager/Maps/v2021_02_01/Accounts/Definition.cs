using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Maps.v2021_02_01.Accounts
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "0cfcacb4d5b58433bfa7cf811f20b1d233cd4dac" 

        public string ApiVersion => "2021-02-01";
        public string Name => "Accounts";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new CreateOrUpdateOperation(),
            new DeleteOperation(),
            new GetOperation(),
            new ListByResourceGroupOperation(),
            new ListBySubscriptionOperation(),
            new ListKeysOperation(),
            new RegenerateKeysOperation(),
            new UpdateOperation(),
        };
    }
}
