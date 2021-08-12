using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.PowerBIDedicated.v2021_01_01.PowerBIDedicated
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "70626b932d16a97361673e0bcba7570284fe0813" 

        public string ApiVersion => "2021-01-01";
        public string Name => "PowerBIDedicated";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new CapacitiesListSkusOperation(),
        };
    }
}
