using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2017_04_01.MessagingPlan
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "ee1dc806b00b73458a7d0de7b05da3c56c756cfb" 

        public string ApiVersion => "2017-04-01";
        public string Name => "MessagingPlan";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new NamespacesGetMessagingPlanOperation(),
        };
    }
}
