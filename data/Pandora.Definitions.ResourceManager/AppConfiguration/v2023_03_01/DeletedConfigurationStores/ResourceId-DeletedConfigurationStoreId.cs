using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AppConfiguration.v2023_03_01.DeletedConfigurationStores;

internal class DeletedConfigurationStoreId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/providers/Microsoft.AppConfiguration/locations/{locationName}/deletedConfigurationStores/{deletedConfigurationStoreName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticSubscriptions", "subscriptions"),
        ResourceIDSegment.SubscriptionId("subscriptionId"),
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftAppConfiguration", "Microsoft.AppConfiguration"),
        ResourceIDSegment.Static("staticLocations", "locations"),
        ResourceIDSegment.UserSpecified("locationName"),
        ResourceIDSegment.Static("staticDeletedConfigurationStores", "deletedConfigurationStores"),
        ResourceIDSegment.UserSpecified("deletedConfigurationStoreName"),
    };
}
