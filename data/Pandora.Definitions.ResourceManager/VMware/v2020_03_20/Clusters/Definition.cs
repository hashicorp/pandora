using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.VMware.v2020_03_20.Clusters
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "d2183715d380084ff04313a73c8803d042fe91b9" 

        public string ApiVersion => "2020-03-20";
        public string Name => "Clusters";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new CreateOrUpdateOperation(),
            new DeleteOperation(),
            new GetOperation(),
            new ListOperation(),
            new UpdateOperation(),
        };
    }
}
