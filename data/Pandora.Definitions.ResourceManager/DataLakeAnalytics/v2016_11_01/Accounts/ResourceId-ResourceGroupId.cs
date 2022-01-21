using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.DataLakeAnalytics.v2016_11_01.Accounts;

internal class ResourceGroupId : ResourceID
{
    public string? CommonAlias => "ResourceGroup";

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {

    };
}
