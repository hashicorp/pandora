using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.ChaosStudio.v2021_09_15_preview.Experiments;

internal class SubscriptionId : ResourceID
{
    public string? CommonAlias => "Subscription";

    public string ID => "/subscriptions/{subscriptionId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {

    };
}
