using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.AnalysisServices.v2017_08_01.Servers
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "60d6c393c7e71b45ebe0976a35fd7a5841993159" 

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
