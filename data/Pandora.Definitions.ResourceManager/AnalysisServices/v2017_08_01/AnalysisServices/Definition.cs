using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.AnalysisServices.v2017_08_01.AnalysisServices
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "fbb7ba76937668739778ac2272b9a607ea0511fc" 

        public string ApiVersion => "2017-08-01";
        public string Name => "AnalysisServices";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new ServersListSkusForNewOperation(),
        };
    }
}
