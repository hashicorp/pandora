using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.PowerBIDedicated.v2021_01_01.Capacities
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "ee1dc806b00b73458a7d0de7b05da3c56c756cfb" 

        public string ApiVersion => "2021-01-01";
        public string Name => "Capacities";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new CheckNameAvailabilityOperation(),
            new CreateOperation(),
            new DeleteOperation(),
            new GetDetailsOperation(),
            new ListOperation(),
            new ListByResourceGroupOperation(),
            new ListSkusForCapacityOperation(),
            new ResumeOperation(),
            new SuspendOperation(),
            new UpdateOperation(),
        };
    }
}
