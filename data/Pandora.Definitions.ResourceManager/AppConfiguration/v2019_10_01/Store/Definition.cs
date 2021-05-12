using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.AppConfiguration.v2019_10_01.Store
{
    public class Definition : ApiDefinition
    {
        public string ApiVersion => "2019-10-01";
        public string Name => "configurationStore";
        public IEnumerable<ApiOperation> Operations => new List<ApiOperation>
        {
            new Create(),
            new Delete(),
            new Get()
        };
        public ResourceID ResourceId => new ConfigurationStoreId();
    }
}