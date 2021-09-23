using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.AppConfiguration.v2020_06_01.PrivateLinkResources
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "06a504c2ecd7e580bfbd67adf4a1cdbeb49eba77" 

        public string ApiVersion => "2020-06-01";
        public string Name => "PrivateLinkResources";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new GetOperation(),
            new ListByConfigurationStoreOperation(),
        };
    }
}
