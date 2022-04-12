using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_01_01_preview.ContainerAppsAuthConfigs;

internal class Definition : ResourceDefinition
{
    public string Name => "ContainerAppsAuthConfigs";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByContainerAppOperation(),
    };
}
