using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Purview.v2021_07_01.Provider
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "3257aacc47c2a03b7964cbb5c6a07ec9f2f232ee" 

        public string ApiVersion => "2021-07-01";
        public string Name => "Provider";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new AccountsCheckNameAvailabilityOperation(),
        };
    }
}
