using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MarketplaceOrdering.v2021_01_01.Agreements;

internal class PlanId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/providers/Microsoft.MarketplaceOrdering/agreements/{publisherId}/offers/{offerId}/plans/{planId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticSubscriptions", "subscriptions"),
        ResourceIDSegment.SubscriptionId("subscriptionId"),
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftMarketplaceOrdering", "Microsoft.MarketplaceOrdering"),
        ResourceIDSegment.Static("staticAgreements", "agreements"),
        ResourceIDSegment.UserSpecified("publisherId"),
        ResourceIDSegment.Static("staticOffers", "offers"),
        ResourceIDSegment.UserSpecified("offerId"),
        ResourceIDSegment.Static("staticPlans", "plans"),
        ResourceIDSegment.UserSpecified("planId"),
    };
}
