using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Purview.v2021_07_01.Account;

internal class SubscriptionId : ResourceID
{
    public string? CommonAlias => "Subscription";

    public string ID => "/subscriptions/{subscriptionId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {

    };
}
