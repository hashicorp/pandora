using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.StoragePool.v2021_08_01.ResourceSkus
{
    internal class Definition : ApiDefinition
    {
        public string ApiVersion => "2021-08-01";
        public string Name => "ResourceSkus";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new ListOperation(),
        };
    }
}
