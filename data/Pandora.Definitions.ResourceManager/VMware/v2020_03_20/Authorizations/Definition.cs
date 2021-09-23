using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.VMware.v2020_03_20.Authorizations
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "06a504c2ecd7e580bfbd67adf4a1cdbeb49eba77" 

        public string ApiVersion => "2020-03-20";
        public string Name => "Authorizations";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new CreateOrUpdateOperation(),
            new DeleteOperation(),
            new GetOperation(),
            new ListOperation(),
        };
    }
}
