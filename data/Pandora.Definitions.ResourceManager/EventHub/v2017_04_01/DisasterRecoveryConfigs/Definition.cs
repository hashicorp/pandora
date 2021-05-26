using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2017_04_01.DisasterRecoveryConfigs
{
    internal class Definition : ApiDefinition
    {
        public string ApiVersion => "2017-04-01";
        public string Name => "DisasterRecoveryConfigs";
        public IEnumerable<ApiOperation> Operations => new List<ApiOperation>
        {
            new BreakPairing(),
            new CreateOrUpdate(),
            new Delete(),
            new FailOver(),
            new Get(),
            new List(),
        };
    }
}