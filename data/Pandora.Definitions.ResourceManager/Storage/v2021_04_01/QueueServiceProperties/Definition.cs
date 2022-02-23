using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.QueueServiceProperties;

internal class Definition : ResourceDefinition
{
    public string Name => "QueueServiceProperties";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new QueueServicesGetServicePropertiesOperation(),
        new QueueServicesListOperation(),
        new QueueServicesSetServicePropertiesOperation(),
    };
}
