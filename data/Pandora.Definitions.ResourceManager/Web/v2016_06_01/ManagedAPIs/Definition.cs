using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Web.v2016_06_01.ManagedAPIs;

internal class Definition : ResourceDefinition
{
    public string Name => "ManagedAPIs";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ManagedApisGetOperation(),
        new ManagedApisListOperation(),
    };
}
