using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.PowerBIDedicated.v2021_01_01.PowerBIDedicated
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "44017a20d8c022217b31e15643595fc7aff87926" 

        public string ApiVersion => "2021-01-01";
        public string Name => "PowerBIDedicated";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new CapacitiesListSkusOperation(),
        };
    }
}
