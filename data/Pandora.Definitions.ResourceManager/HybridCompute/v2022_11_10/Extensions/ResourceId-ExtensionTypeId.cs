using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.HybridCompute.v2022_11_10.Extensions;

internal class ExtensionTypeId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/providers/Microsoft.HybridCompute/locations/{location}/publishers/{publisher}/extensionTypes/{extensionType}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticSubscriptions", "subscriptions"),
        ResourceIDSegment.SubscriptionId("subscriptionId"),
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftHybridCompute", "Microsoft.HybridCompute"),
        ResourceIDSegment.Static("staticLocations", "locations"),
        ResourceIDSegment.UserSpecified("location"),
        ResourceIDSegment.Static("staticPublishers", "publishers"),
        ResourceIDSegment.UserSpecified("publisher"),
        ResourceIDSegment.Static("staticExtensionTypes", "extensionTypes"),
        ResourceIDSegment.UserSpecified("extensionType"),
    };
}
