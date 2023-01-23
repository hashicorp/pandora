using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Storage.v2022_05_01.TableService;

internal class TableId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{storageAccountName}/tableServices/default/tables/{tableName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticSubscriptions", "subscriptions"),
        ResourceIDSegment.SubscriptionId("subscriptionId"),
        ResourceIDSegment.Static("staticResourceGroups", "resourceGroups"),
        ResourceIDSegment.ResourceGroup("resourceGroupName"),
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftStorage", "Microsoft.Storage"),
        ResourceIDSegment.Static("staticStorageAccounts", "storageAccounts"),
        ResourceIDSegment.UserSpecified("storageAccountName"),
        ResourceIDSegment.Static("staticTableServices", "tableServices"),
        ResourceIDSegment.Static("staticDefault", "default"),
        ResourceIDSegment.Static("staticTables", "tables"),
        ResourceIDSegment.UserSpecified("tableName"),
    };
}
