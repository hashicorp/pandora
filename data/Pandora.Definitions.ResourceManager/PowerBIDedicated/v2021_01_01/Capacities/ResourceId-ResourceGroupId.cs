using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.PowerBIDedicated.v2021_01_01.Capacities;

internal class ResourceGroupId : ResourceID
{
    public string? CommonAlias => "ResourceGroup";

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {

    };
}
