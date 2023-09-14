using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Migrate.v2023_06_06.WebAppRunAsAccountsController;

internal class RunAsAccountId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OffAzure/serverSites/{serverSiteName}/runAsAccounts/{runAsAccountName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticSubscriptions", "subscriptions"),
        ResourceIDSegment.SubscriptionId("subscriptionId"),
        ResourceIDSegment.Static("staticResourceGroups", "resourceGroups"),
        ResourceIDSegment.ResourceGroup("resourceGroupName"),
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftOffAzure", "Microsoft.OffAzure"),
        ResourceIDSegment.Static("staticServerSites", "serverSites"),
        ResourceIDSegment.UserSpecified("serverSiteName"),
        ResourceIDSegment.Static("staticRunAsAccounts", "runAsAccounts"),
        ResourceIDSegment.UserSpecified("runAsAccountName"),
    };
}
