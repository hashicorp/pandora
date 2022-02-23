using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.ObjectReplicationPolicies;

internal class Definition : ResourceDefinition
{
    public string Name => "ObjectReplicationPolicies";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
    };
}
