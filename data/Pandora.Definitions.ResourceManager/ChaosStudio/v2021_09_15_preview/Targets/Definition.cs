using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.ChaosStudio.v2021_09_15_preview.Targets
{
    internal class Definition : ResourceDefinition
    {
        public string Name => "Targets";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new CreateOrUpdateOperation(),
            new DeleteOperation(),
            new GetOperation(),
            new ListOperation(),
        };
    }
}
