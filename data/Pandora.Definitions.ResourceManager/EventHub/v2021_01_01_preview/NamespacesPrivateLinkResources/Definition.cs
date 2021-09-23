using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2021_01_01_preview.NamespacesPrivateLinkResources
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "06a504c2ecd7e580bfbd67adf4a1cdbeb49eba77" 

        public string ApiVersion => "2021-01-01-preview";
        public string Name => "NamespacesPrivateLinkResources";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new PrivateLinkResourcesGetOperation(),
        };
    }
}
