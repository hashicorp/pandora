using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Purview.v2021_07_01.PrivateEndpointConnection;

internal class Definition : ResourceDefinition
{
    public string Name => "PrivateEndpointConnection";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByAccountOperation(),
    };
}
