using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Maps.v2021_02_01.Accounts
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "1c7df99f6a84335cfd7bf5be8c800d72c1dddbc2" 

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
