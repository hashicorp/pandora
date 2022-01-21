using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.FrontDoor.v2020_04_01.WebApplicationFirewallManagedRuleSets;

internal class SubscriptionId : ResourceID
{
    public string? CommonAlias => "Subscription";

    public string ID => "/subscriptions/{subscriptionId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {

    };
}
