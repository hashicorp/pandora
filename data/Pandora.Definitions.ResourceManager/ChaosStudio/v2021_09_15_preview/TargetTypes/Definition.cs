using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.ChaosStudio.v2021_09_15_preview.TargetTypes
{
    internal class Definition : ApiDefinition
    {
        public string ApiVersion => "2021-09-15-preview";
        public string Name => "TargetTypes";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new GetOperation(),
            new ListOperation(),
        };
    }
}
