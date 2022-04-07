using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2021_09_01.Webhooks;

internal class Definition : ResourceDefinition
{
    public string Name => "Webhooks";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new GetCallbackConfigOperation(),
        new ListOperation(),
        new ListEventsOperation(),
        new PingOperation(),
        new UpdateOperation(),
    };
}
