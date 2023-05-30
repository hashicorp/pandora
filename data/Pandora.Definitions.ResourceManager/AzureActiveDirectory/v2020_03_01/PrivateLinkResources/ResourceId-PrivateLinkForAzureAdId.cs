using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AzureActiveDirectory.v2020_03_01.PrivateLinkResources;

internal class PrivateLinkForAzureAdId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AADIAM/privateLinkForAzureAd/{privateLinkForAzureAdName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticSubscriptions", "subscriptions"),
        ResourceIDSegment.SubscriptionId("subscriptionId"),
        ResourceIDSegment.Static("staticResourceGroups", "resourceGroups"),
        ResourceIDSegment.ResourceGroup("resourceGroupName"),
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftAADIAM", "Microsoft.AADIAM"),
        ResourceIDSegment.Static("staticPrivateLinkForAzureAd", "privateLinkForAzureAd"),
        ResourceIDSegment.UserSpecified("privateLinkForAzureAdName"),
    };
}
