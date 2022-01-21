using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2017_04_01.Namespaces;

internal class SubscriptionId : ResourceID
{
    public string? CommonAlias => "Subscription";

    public string ID => "/subscriptions/{subscriptionId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {

    };
}
