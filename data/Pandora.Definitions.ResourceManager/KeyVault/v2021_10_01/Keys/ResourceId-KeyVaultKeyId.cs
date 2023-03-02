using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.KeyVault.v2021_10_01.Keys;

internal class KeyVaultKeyId : ResourceID
{
    public string? CommonAlias => "KeyVaultKey";

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.KeyVault/vaults/{vaultName}/keys/{keyName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("subscriptions", "subscriptions"),
        ResourceIDSegment.SubscriptionId("subscriptionId"),
        ResourceIDSegment.Static("resourceGroups", "resourceGroups"),
        ResourceIDSegment.ResourceGroup("resourceGroupName"),
        ResourceIDSegment.Static("providers", "providers"),
        ResourceIDSegment.ResourceProvider("resourceProvider", "Microsoft.KeyVault"),
        ResourceIDSegment.Static("vaults", "vaults"),
        ResourceIDSegment.UserSpecified("vaultName"),
        ResourceIDSegment.Static("keys", "keys"),
        ResourceIDSegment.UserSpecified("keyName"),
    };
}
