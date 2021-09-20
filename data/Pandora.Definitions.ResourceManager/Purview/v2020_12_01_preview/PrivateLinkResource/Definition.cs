using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Purview.v2020_12_01_preview.PrivateLinkResource
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "1c7df99f6a84335cfd7bf5be8c800d72c1dddbc2" 

        public string ApiVersion => "2020-12-01-preview";
        public string Name => "PrivateLinkResource";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new GetByGroupIdOperation(),
            new ListByAccountOperation(),
        };
    }
}
