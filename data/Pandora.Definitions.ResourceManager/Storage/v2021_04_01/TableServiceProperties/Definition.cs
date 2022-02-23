using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.TableServiceProperties;

internal class Definition : ResourceDefinition
{
    public string Name => "TableServiceProperties";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new TableServicesGetServicePropertiesOperation(),
        new TableServicesListOperation(),
        new TableServicesSetServicePropertiesOperation(),
    };
}
