using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2017_04_01.Regions
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "3257aacc47c2a03b7964cbb5c6a07ec9f2f232ee" 

        public string ApiVersion => "2017-04-01";
        public string Name => "Regions";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new ListBySkuOperation(),
        };
    }
}
