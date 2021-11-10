using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.DataLakeAnalytics.v2016_11_01.Locations
{
    internal class Definition : ApiDefinition
    {
        public string ApiVersion => "2016-11-01";
        public string Name => "Locations";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new GetCapabilityOperation(),
        };
    }
}
