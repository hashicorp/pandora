using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2021_11_01.CheckNameAvailabilityNamespaces;

internal class Definition : ResourceDefinition
{
    public string Name => "CheckNameAvailabilityNamespaces";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new NamespacesCheckNameAvailabilityOperation(),
    };
}
