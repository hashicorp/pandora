using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.TrafficManager.v2018_08_01.Profiles
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "e7682aa897902920f3a95b2f358b6f7729d18666" 

        public string ApiVersion => "2018-08-01";
        public string Name => "Profiles";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new CreateOrUpdate(),
            new Delete(),
            new Get(),
            new ListByResourceGroup(),
            new Update(),
        };
    }
}
