using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.CheckNameAvailabilityNamespaces
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "b2bddfe2e59b5b14e559e0433b6e6d057bcff95d" 

        public string ApiVersion => "2018-01-01-preview";
        public string Name => "CheckNameAvailabilityNamespaces";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new NamespacesCheckNameAvailabilityOperation(),
        };
    }
}
