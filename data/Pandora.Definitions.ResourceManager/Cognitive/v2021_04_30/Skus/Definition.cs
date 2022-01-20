using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Cognitive.v2021_04_30.Skus
{
    internal class Definition : ResourceDefinition
    {
        public string Name => "Skus";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new ResourceSkusListOperation(),
        };
    }
}
