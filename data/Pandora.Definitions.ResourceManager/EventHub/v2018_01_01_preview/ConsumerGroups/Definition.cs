using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.ConsumerGroups
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "1c7df99f6a84335cfd7bf5be8c800d72c1dddbc2" 

        public string ApiVersion => "2018-01-01-preview";
        public string Name => "ConsumerGroups";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new CreateOrUpdateOperation(),
            new DeleteOperation(),
            new GetOperation(),
            new ListByEventHubOperation(),
        };
    }
}
