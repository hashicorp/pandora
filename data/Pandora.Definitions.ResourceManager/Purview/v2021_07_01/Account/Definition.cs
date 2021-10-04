using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Purview.v2021_07_01.Account
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "fd7603f9a8acb1decf94f7770a0bfe7b78df9b20" 

        public string ApiVersion => "2021-07-01";
        public string Name => "Account";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new AddRootCollectionAdminOperation(),
            new CreateOrUpdateOperation(),
            new DeleteOperation(),
            new GetOperation(),
            new ListByResourceGroupOperation(),
            new ListBySubscriptionOperation(),
            new ListKeysOperation(),
            new UpdateOperation(),
        };
    }
}
