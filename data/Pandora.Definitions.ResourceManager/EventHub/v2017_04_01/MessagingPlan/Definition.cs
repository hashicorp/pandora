using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2017_04_01.MessagingPlan
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "5844fecb75c31a578ab2548caa8524e6126b0520" 

        public string ApiVersion => "2017-04-01";
        public string Name => "MessagingPlan";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new NamespacesGetMessagingPlanOperation(),
        };
    }
}
