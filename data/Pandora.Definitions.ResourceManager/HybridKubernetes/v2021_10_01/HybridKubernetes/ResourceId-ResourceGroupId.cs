using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.HybridKubernetes.v2021_10_01.HybridKubernetes;

internal class ResourceGroupId : ResourceID
{
    public string? CommonAlias => "ResourceGroup";

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {

    };
}
