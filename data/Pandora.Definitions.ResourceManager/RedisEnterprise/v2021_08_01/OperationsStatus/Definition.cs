using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.RedisEnterprise.v2021_08_01.OperationsStatus
{
    internal class Definition : ResourceDefinition
    {
        public string Name => "OperationsStatus";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new GetOperation(),
        };
    }
}
