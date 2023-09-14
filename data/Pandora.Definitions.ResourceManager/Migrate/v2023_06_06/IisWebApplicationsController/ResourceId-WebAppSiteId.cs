using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Migrate.v2023_06_06.IisWebApplicationsController;

internal class WebAppSiteId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OffAzure/masterSites/{masterSiteName}/webAppSites/{webAppSiteName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticSubscriptions", "subscriptions"),
        ResourceIDSegment.SubscriptionId("subscriptionId"),
        ResourceIDSegment.Static("staticResourceGroups", "resourceGroups"),
        ResourceIDSegment.ResourceGroup("resourceGroupName"),
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftOffAzure", "Microsoft.OffAzure"),
        ResourceIDSegment.Static("staticMasterSites", "masterSites"),
        ResourceIDSegment.UserSpecified("masterSiteName"),
        ResourceIDSegment.Static("staticWebAppSites", "webAppSites"),
        ResourceIDSegment.UserSpecified("webAppSiteName"),
    };
}
