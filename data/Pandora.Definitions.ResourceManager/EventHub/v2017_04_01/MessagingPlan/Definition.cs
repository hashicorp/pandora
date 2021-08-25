using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2017_04_01.MessagingPlan
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "44017a20d8c022217b31e15643595fc7aff87926" 

        public string ApiVersion => "2017-04-01";
        public string Name => "MessagingPlan";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new NamespacesGetMessagingPlanOperation(),
        };
    }
}
