using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MarketplaceOrdering.v2015_06_01.Agreements;

internal class OfferPlanId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/providers/Microsoft.MarketplaceOrdering/offerTypes/virtualmachine/publishers/{publisherId}/offers/{offerId}/plans/{planId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticSubscriptions", "subscriptions"),
        ResourceIDSegment.SubscriptionId("subscriptionId"),
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftMarketplaceOrdering", "Microsoft.MarketplaceOrdering"),
        ResourceIDSegment.Static("staticOfferTypes", "offerTypes"),
        ResourceIDSegment.Static("offerType", "virtualmachine"),
        ResourceIDSegment.Static("staticPublishers", "publishers"),
        ResourceIDSegment.UserSpecified("publisherId"),
        ResourceIDSegment.Static("staticOffers", "offers"),
        ResourceIDSegment.UserSpecified("offerId"),
        ResourceIDSegment.Static("staticPlans", "plans"),
        ResourceIDSegment.UserSpecified("planId"),
    };
}
