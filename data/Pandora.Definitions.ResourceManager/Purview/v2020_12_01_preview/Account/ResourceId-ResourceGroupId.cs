using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Purview.v2020_12_01_preview.Account;

internal class ResourceGroupId : ResourceID
{
    public string? CommonAlias => "ResourceGroup";

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {

    };
}
