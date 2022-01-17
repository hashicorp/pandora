using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.ChaosStudio.v2021_09_15_preview.Capabilities
{
    internal class Definition : ApiDefinition
    {
        public string ApiVersion => "2021-09-15-preview";
        public string Name => "Capabilities";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new CapabilityTypesGetOperation(),
            new CreateOrUpdateOperation(),
            new DeleteOperation(),
            new GetOperation(),
            new ListOperation(),
        };
    }
}
