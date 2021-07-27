using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Maps.v2021_02_01.Accounts
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "e7682aa897902920f3a95b2f358b6f7729d18666" 

        public string ApiVersion => "2021-02-01";
        public string Name => "Accounts";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new CreateOrUpdate(),
            new Delete(),
            new Get(),
            new ListByResourceGroup(),
            new ListKeys(),
            new RegenerateKeys(),
            new Update(),
        };
    }
}
