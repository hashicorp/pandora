using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2021_01_01_preview.DisasterRecoveryConfigs
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "fbb7ba76937668739778ac2272b9a607ea0511fc" 

        public string ApiVersion => "2021-01-01-preview";
        public string Name => "DisasterRecoveryConfigs";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new BreakPairingOperation(),
            new CreateOrUpdateOperation(),
            new DeleteOperation(),
            new FailOverOperation(),
            new GetOperation(),
            new ListOperation(),
        };
    }
}
