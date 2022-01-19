using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.StoragePool.v2021_08_01.IscsiTargets
{
    internal class Definition : ApiDefinition
    {
        public string Name => "IscsiTargets";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new CreateOrUpdateOperation(),
            new DeleteOperation(),
            new GetOperation(),
            new ListByDiskPoolOperation(),
            new UpdateOperation(),
        };
    }
}
