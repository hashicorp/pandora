using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Batch.v2023_05_01.PrivateLinkResource;

internal class PrivateLinkResourceId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Batch/batchAccounts/{batchAccountName}/privateLinkResources/{privateLinkResourceName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticSubscriptions", "subscriptions"),
        ResourceIDSegment.SubscriptionId("subscriptionId"),
        ResourceIDSegment.Static("staticResourceGroups", "resourceGroups"),
        ResourceIDSegment.ResourceGroup("resourceGroupName"),
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftBatch", "Microsoft.Batch"),
        ResourceIDSegment.Static("staticBatchAccounts", "batchAccounts"),
        ResourceIDSegment.UserSpecified("batchAccountName"),
        ResourceIDSegment.Static("staticPrivateLinkResources", "privateLinkResources"),
        ResourceIDSegment.UserSpecified("privateLinkResourceName"),
    };
}
