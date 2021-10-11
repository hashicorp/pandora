using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.VMware.v2020_03_20.Locations
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "865f0857a8785640f9bca0ab9842d29be589f2a8" 

        public string ApiVersion => "2020-03-20";
        public string Name => "Locations";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new CheckQuotaAvailabilityOperation(),
            new CheckTrialAvailabilityOperation(),
        };
    }
}
