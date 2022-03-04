using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.HealthCareApis.v2021_06_01_preview.PrivateLinkResources;

internal class Definition : ResourceDefinition
{
    public string Name => "PrivateLinkResources";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetOperation(),
        new ListByServiceOperation(),
    };
}
