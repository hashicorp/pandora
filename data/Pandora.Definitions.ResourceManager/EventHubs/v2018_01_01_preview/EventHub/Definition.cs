using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHubs.v2018_01_01_preview.EventHub
{
    internal class Definition : ApiDefinition
    {
        public string ApiVersion => "2018-01-01-preview";
        public string Name => "eventhub";
        public IEnumerable<ApiOperation> Operations => new List<ApiOperation>
        {
            new Create(),
            new Get()
        };
        public ResourceID ResourceId => new EventHubId();
    }
}