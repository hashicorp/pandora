using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2017_04_01.ConsumerGroups
{
    internal class Definition : ApiDefinition
    {
        public string ApiVersion => "v2017-04-01";
        public string Name => "ConsumerGroups";
        public IEnumerable<ApiOperation> Operations => new List<ApiOperation>
        {
            new CreateOrUpdate(),
            new Delete(),
            new Get(),
            new ListByEventHub(),
        };
    }
}