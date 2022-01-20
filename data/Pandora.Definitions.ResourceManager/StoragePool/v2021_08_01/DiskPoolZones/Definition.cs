using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.StoragePool.v2021_08_01.DiskPoolZones
{
    internal class Definition : ResourceDefinition
    {
        public string Name => "DiskPoolZones";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new ListOperation(),
        };
    }
}
