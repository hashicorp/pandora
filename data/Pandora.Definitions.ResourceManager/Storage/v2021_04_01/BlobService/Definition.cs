using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.BlobService;

internal class Definition : ResourceDefinition
{
    public string Name => "BlobService";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetServicePropertiesOperation(),
        new ListOperation(),
        new SetServicePropertiesOperation(),
    };
}
