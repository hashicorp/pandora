using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Elastic.v2020_07_01.MonitorsResource;

internal class Definition : ResourceDefinition
{
    public string Name => "MonitorsResource";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new MonitorsCreateOperation(),
        new MonitorsDeleteOperation(),
        new MonitorsGetOperation(),
        new MonitorsListOperation(),
        new MonitorsListByResourceGroupOperation(),
        new MonitorsUpdateOperation(),
    };
}
