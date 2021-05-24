using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2017_04_01.EventHubs
{
    internal class Definition : ApiDefinition
    {
        public string ApiVersion => "v2017-04-01";
        public string Name => "EventHubs";
        public IEnumerable<ApiOperation> Operations => new List<ApiOperation>
        {
            new CreateOrUpdate(),
            new Delete(),
            new DeleteAuthorizationRule(),
            new Get(),
            new GetAuthorizationRule(),
            new ListByNamespace(),
        };
    }
}