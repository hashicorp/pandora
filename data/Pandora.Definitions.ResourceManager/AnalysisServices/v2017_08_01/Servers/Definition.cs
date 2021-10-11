using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.AnalysisServices.v2017_08_01.Servers
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "865f0857a8785640f9bca0ab9842d29be589f2a8" 

        public string ApiVersion => "2017-08-01";
        public string Name => "Servers";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new CheckNameAvailabilityOperation(),
            new CreateOperation(),
            new DeleteOperation(),
            new DissociateGatewayOperation(),
            new GetDetailsOperation(),
            new ListOperation(),
            new ListByResourceGroupOperation(),
            new ListGatewayStatusOperation(),
            new ListSkusForExistingOperation(),
            new ResumeOperation(),
            new SuspendOperation(),
            new UpdateOperation(),
        };
    }
}
