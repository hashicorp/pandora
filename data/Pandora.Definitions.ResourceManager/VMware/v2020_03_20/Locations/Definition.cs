using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.VMware.v2020_03_20.Locations
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "e68d33c8165c51219c4643eead40efd6a9ab7bd2" 

        public string ApiVersion => "2020-03-20";
        public string Name => "Locations";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new CheckQuotaAvailabilityOperation(),
            new CheckTrialAvailabilityOperation(),
        };
    }
}
