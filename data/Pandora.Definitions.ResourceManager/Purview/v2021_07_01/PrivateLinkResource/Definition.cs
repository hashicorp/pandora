using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Purview.v2021_07_01.PrivateLinkResource
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "e07d7900e7e02c9bb6caba0ee15f0e280e97b8f5" 

        public string ApiVersion => "2021-07-01";
        public string Name => "PrivateLinkResource";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new GetByGroupIdOperation(),
            new ListByAccountOperation(),
        };
    }
}
