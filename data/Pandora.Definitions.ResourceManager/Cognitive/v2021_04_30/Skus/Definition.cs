using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Cognitive.v2021_04_30.Skus
{
    internal class Definition : ApiDefinition
    {
        public string ApiVersion => "2021-04-30";
        public string Name => "Skus";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new ResourceSkusListOperation(),
        };
    }
}
