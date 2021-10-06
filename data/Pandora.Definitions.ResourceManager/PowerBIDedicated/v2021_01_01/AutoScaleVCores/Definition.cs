using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.PowerBIDedicated.v2021_01_01.AutoScaleVCores
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "191a721de644cc3f872f4fe9d676cf366083a106" 

        public string ApiVersion => "2021-01-01";
        public string Name => "AutoScaleVCores";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new CreateOperation(),
            new DeleteOperation(),
            new GetOperation(),
            new ListByResourceGroupOperation(),
            new ListBySubscriptionOperation(),
            new UpdateOperation(),
        };
    }
}
