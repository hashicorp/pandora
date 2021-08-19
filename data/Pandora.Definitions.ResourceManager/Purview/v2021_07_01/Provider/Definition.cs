using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Purview.v2021_07_01.Provider
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "b2bddfe2e59b5b14e559e0433b6e6d057bcff95d" 

        public string ApiVersion => "2021-07-01";
        public string Name => "Provider";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new AccountsCheckNameAvailabilityOperation(),
        };
    }
}
