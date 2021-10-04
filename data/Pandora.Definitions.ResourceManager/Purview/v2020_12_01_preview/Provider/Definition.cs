using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Purview.v2020_12_01_preview.Provider
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "28e60e3f539b44b60e7b4d6fa2cf4476519bcf93" 

        public string ApiVersion => "2020-12-01-preview";
        public string Name => "Provider";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new AccountsCheckNameAvailabilityOperation(),
        };
    }
}
