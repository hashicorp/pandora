using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.KubernetesConfiguration.v2021_09_01.ClusterExtensions;

internal class Definition : ResourceDefinition
{
    public string Name => "ClusterExtensions";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ExtensionsCreateOperation(),
        new ExtensionsDeleteOperation(),
        new ExtensionsGetOperation(),
        new ExtensionsListOperation(),
        new ExtensionsUpdateOperation(),
    };
}
