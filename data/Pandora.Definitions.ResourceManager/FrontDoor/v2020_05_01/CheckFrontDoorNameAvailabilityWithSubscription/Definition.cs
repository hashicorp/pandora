using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.FrontDoor.v2020_05_01.CheckFrontDoorNameAvailabilityWithSubscription
{
    internal class Definition : ApiDefinition
    {
        public string ApiVersion => "2020-05-01";
        public string Name => "CheckFrontDoorNameAvailabilityWithSubscription";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new FrontDoorNameAvailabilityWithSubscriptionCheckOperation(),
        };
    }
}
