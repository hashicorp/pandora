using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.QueueService;

internal class Definition : ResourceDefinition
{
    public string Name => "QueueService";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new QueueCreateOperation(),
        new QueueDeleteOperation(),
        new QueueGetOperation(),
        new QueueListOperation(),
        new QueueUpdateOperation(),
    };
}
