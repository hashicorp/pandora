using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.VMware.v2020_03_20.PrivateClouds
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "28e60e3f539b44b60e7b4d6fa2cf4476519bcf93" 

        public string ApiVersion => "2020-03-20";
        public string Name => "PrivateClouds";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new CreateOrUpdateOperation(),
            new DeleteOperation(),
            new GetOperation(),
            new ListOperation(),
            new ListAdminCredentialsOperation(),
            new ListInSubscriptionOperation(),
            new UpdateOperation(),
        };
    }
}
