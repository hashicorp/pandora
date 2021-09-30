using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Purview.v2020_12_01_preview.Provider
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "d23ad89e8c3e98c4f941fd9ec3db6ab39951a494" 

        public string ApiVersion => "2020-12-01-preview";
        public string Name => "Provider";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new AccountsCheckNameAvailabilityOperation(),
        };
    }
}
