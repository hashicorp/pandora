using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.BlobContainers;

internal class ImmutabilityPolicyId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers/{containerName}/immutabilityPolicies/{immutabilityPolicyName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticSubscriptions", "subscriptions"),
        ResourceIDSegment.SubscriptionId("subscriptionId"),
        ResourceIDSegment.Static("staticResourceGroups", "resourceGroups"),
        ResourceIDSegment.ResourceGroup("resourceGroupName"),
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftStorage", "Microsoft.Storage"),
        ResourceIDSegment.Static("staticStorageAccounts", "storageAccounts"),
        ResourceIDSegment.UserSpecified("accountName"),
        ResourceIDSegment.Static("staticBlobServices", "blobServices"),
        ResourceIDSegment.Static("staticDefault", "default"),
        ResourceIDSegment.Static("staticContainers", "containers"),
        ResourceIDSegment.UserSpecified("containerName"),
        ResourceIDSegment.Static("staticImmutabilityPolicies", "immutabilityPolicies"),
        ResourceIDSegment.Constant("immutabilityPolicyName", typeof(ImmutabilityPolicyNameConstant)),
    };
}
