using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Subscription.v2021_10_01.Subscriptions;

internal class SubscriptionOperationId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/providers/Microsoft.Subscription/subscriptionOperations/{operationId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftSubscription", "Microsoft.Subscription"),
        ResourceIDSegment.Static("staticSubscriptionOperations", "subscriptionOperations"),
        ResourceIDSegment.UserSpecified("operationId"),
    };
}
