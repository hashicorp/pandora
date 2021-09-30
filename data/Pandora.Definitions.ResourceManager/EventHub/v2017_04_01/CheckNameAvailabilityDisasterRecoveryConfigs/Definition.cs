using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2017_04_01.CheckNameAvailabilityDisasterRecoveryConfigs
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "d23ad89e8c3e98c4f941fd9ec3db6ab39951a494" 

        public string ApiVersion => "2017-04-01";
        public string Name => "CheckNameAvailabilityDisasterRecoveryConfigs";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new DisasterRecoveryConfigsCheckNameAvailabilityOperation(),
        };
    }
}
