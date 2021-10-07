using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Purview.v2021_07_01.PrivateLinkResource
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "1ec9a8fe851a92ff4c241110cef58238ced59c6c" 

        public string ApiVersion => "2021-07-01";
        public string Name => "PrivateLinkResource";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new GetByGroupIdOperation(),
            new ListByAccountOperation(),
        };
    }
}
