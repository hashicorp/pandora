using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Resources.v2018_05_01.ResourceGroup
{
    internal class Definition : ApiDefinition
    {
        public string ApiVersion => "2018-05-01";
        
        public string Name => "resourceGroups";

        public IEnumerable<ApiOperation> Operations => new List<ApiOperation>
        {
            new Create(),
            new Delete(),
            new Get(),
            new Update()
        };
        
        public ResourceID ResourceId => new ResourceGroupId();   
    }
}