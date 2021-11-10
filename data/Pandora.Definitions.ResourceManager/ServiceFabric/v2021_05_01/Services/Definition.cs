using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.ServiceFabric.v2021_05_01.Services
{
    internal class Definition : ApiDefinition
    {
        public string ApiVersion => "2021-05-01";
        public string Name => "Services";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new UpdateOperation(),
        };
    }
}
