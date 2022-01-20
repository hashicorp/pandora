using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2017_04_01.MessagingPlan
{
    internal class Definition : ResourceDefinition
    {
        public string Name => "MessagingPlan";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new NamespacesGetMessagingPlanOperation(),
        };
    }
}
