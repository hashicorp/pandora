using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.AppConfiguration.v2020_06_01.Store
{
    public class Definition: ApiDefinition
    {
        public string ApiVersion => "2020-06-01";
        public string Name => "configurationStore";
        public IEnumerable<ApiOperation> Operations => new List<ApiOperation>
        {
            new Create(),
            new Delete(),
            new Get(),
            new List()
        };
    }
}