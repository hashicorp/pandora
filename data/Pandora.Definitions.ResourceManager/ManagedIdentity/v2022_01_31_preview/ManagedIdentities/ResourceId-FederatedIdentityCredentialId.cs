using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ManagedIdentity.v2022_01_31_preview.ManagedIdentities;

internal class FederatedIdentityCredentialId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{userAssignedIdentityName}/federatedIdentityCredentials/{federatedIdentityCredentialName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticSubscriptions", "subscriptions"),
        ResourceIDSegment.SubscriptionId("subscriptionId"),
        ResourceIDSegment.Static("staticResourceGroups", "resourceGroups"),
        ResourceIDSegment.ResourceGroup("resourceGroupName"),
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftManagedIdentity", "Microsoft.ManagedIdentity"),
        ResourceIDSegment.Static("staticUserAssignedIdentities", "userAssignedIdentities"),
        ResourceIDSegment.UserSpecified("userAssignedIdentityName"),
        ResourceIDSegment.Static("staticFederatedIdentityCredentials", "federatedIdentityCredentials"),
        ResourceIDSegment.UserSpecified("federatedIdentityCredentialName"),
    };
}
