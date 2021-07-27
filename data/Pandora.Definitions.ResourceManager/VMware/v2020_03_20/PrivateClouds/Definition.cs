using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.VMware.v2020_03_20.PrivateClouds
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "e3dbb827d99eaadf132075707373f6b4bda08fd9" 

        public string ApiVersion => "2020-03-20";
        public string Name => "PrivateClouds";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new CreateOrUpdate(),
            new Delete(),
            new Get(),
            new List(),
            new ListAdminCredentials(),
            new Update(),
        };
    }
}
