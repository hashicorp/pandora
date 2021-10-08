using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Maps.v2021_02_01.Creators
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "b28a542b3eb4f2f4f384b14b635d0a835df818cd" 

        public string ApiVersion => "2021-02-01";
        public string Name => "Creators";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new CreateOrUpdateOperation(),
            new DeleteOperation(),
            new GetOperation(),
            new ListByAccountOperation(),
            new UpdateOperation(),
        };
    }
}
