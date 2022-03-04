using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.HealthCareApis.v2021_06_01_preview.PrivateEndpointConnections;

internal class Definition : ResourceDefinition
{
    public string Name => "PrivateEndpointConnections";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByServiceOperation(),
    };
}
