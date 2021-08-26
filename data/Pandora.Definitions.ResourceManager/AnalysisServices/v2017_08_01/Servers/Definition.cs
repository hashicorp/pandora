using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.AnalysisServices.v2017_08_01.Servers
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "5844fecb75c31a578ab2548caa8524e6126b0520" 

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
            new ListOperationStatusesOperation(),
            new ListSkusForExistingOperation(),
            new ResumeOperation(),
            new SuspendOperation(),
            new UpdateOperation(),
        };
    }
}
