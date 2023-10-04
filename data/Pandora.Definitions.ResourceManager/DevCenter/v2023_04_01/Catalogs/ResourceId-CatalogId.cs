using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DevCenter.v2023_04_01.Catalogs;

internal class CatalogId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevCenter/devcenters/{devcenterName}/catalogs/{catalogName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticSubscriptions", "subscriptions"),
        ResourceIDSegment.SubscriptionId("subscriptionId"),
        ResourceIDSegment.Static("staticResourceGroups", "resourceGroups"),
        ResourceIDSegment.ResourceGroup("resourceGroupName"),
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftDevCenter", "Microsoft.DevCenter"),
        ResourceIDSegment.Static("staticDevcenters", "devcenters"),
        ResourceIDSegment.UserSpecified("devcenterName"),
        ResourceIDSegment.Static("staticCatalogs", "catalogs"),
        ResourceIDSegment.UserSpecified("catalogName"),
    };
}
