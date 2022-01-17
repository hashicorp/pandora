using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.ChaosStudio.v2021_09_15_preview.CapabilityTypes
{
    internal class Definition : ApiDefinition
    {
        public string ApiVersion => "2021-09-15-preview";
        public string Name => "CapabilityTypes";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new ListOperation(),
        };
    }
}
