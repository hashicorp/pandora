using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.StoragePool.v2021_08_01
{
    public partial class Definition : ApiVersionDefinition
    {
        public string ApiVersion => "2021-08-01";
        public bool Preview => false;

        public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
        {
            new DiskPoolZones.Definition(),
            new DiskPools.Definition(),
            new IscsiTargets.Definition(),
            new ResourceSkus.Definition(),
        };
    }
}
