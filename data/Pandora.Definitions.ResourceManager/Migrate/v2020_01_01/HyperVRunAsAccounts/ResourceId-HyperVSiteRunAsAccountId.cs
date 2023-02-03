using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Migrate.v2020_01_01.HyperVRunAsAccounts;

internal class HyperVSiteRunAsAccountId : ResourceID
{
    public string? CommonAlias => "HyperVSiteRunAsAccount";

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OffAzure/hyperVSites/{hyperVSiteName}/runAsAccounts/{runAsAccountName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("subscriptions", "subscriptions"),
        ResourceIDSegment.SubscriptionId("subscriptionId"),
        ResourceIDSegment.Static("resourceGroups", "resourceGroups"),
        ResourceIDSegment.ResourceGroup("resourceGroupName"),
        ResourceIDSegment.Static("providers", "providers"),
        ResourceIDSegment.ResourceProvider("resourceProvider", "Microsoft.OffAzure"),
        ResourceIDSegment.Static("hyperVSites", "hyperVSites"),
        ResourceIDSegment.UserSpecified("hyperVSiteName"),
        ResourceIDSegment.Static("runAsAccounts", "runAsAccounts"),
        ResourceIDSegment.UserSpecified("runAsAccountName"),
    };
}
