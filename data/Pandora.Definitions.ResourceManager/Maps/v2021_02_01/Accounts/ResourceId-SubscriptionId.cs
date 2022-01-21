using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Maps.v2021_02_01.Accounts;

internal class SubscriptionId : ResourceID
{
    public string? CommonAlias => "Subscription";

    public string ID => "/subscriptions/{subscriptionId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {

    };
}
