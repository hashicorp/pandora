using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.AnalysisServices.v2017_08_01.AnalysisServices
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "e07d7900e7e02c9bb6caba0ee15f0e280e97b8f5" 

        public string ApiVersion => "2017-08-01";
        public string Name => "AnalysisServices";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new ServersListSkusForNewOperation(),
        };
    }
}
