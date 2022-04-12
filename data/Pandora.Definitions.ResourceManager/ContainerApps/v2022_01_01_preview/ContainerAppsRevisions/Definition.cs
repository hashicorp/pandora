using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_01_01_preview.ContainerAppsRevisions;

internal class Definition : ResourceDefinition
{
    public string Name => "ContainerAppsRevisions";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ActivateRevisionOperation(),
        new DeactivateRevisionOperation(),
        new GetRevisionOperation(),
        new ListRevisionsOperation(),
        new RestartRevisionOperation(),
    };
}
