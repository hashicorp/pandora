using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2021_02_01_preview.LongTermRetentionBackups;

internal class LongTermRetentionDatabaseLongTermRetentionBackupId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/locations/{locationName}/longTermRetentionServers/{longTermRetentionServerName}/longTermRetentionDatabases/{longTermRetentionDatabaseName}/longTermRetentionBackups/{longTermRetentionBackupName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticSubscriptions", "subscriptions"),
        ResourceIDSegment.SubscriptionId("subscriptionId"),
        ResourceIDSegment.Static("staticResourceGroups", "resourceGroups"),
        ResourceIDSegment.ResourceGroup("resourceGroupName"),
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftSql", "Microsoft.Sql"),
        ResourceIDSegment.Static("staticLocations", "locations"),
        ResourceIDSegment.UserSpecified("locationName"),
        ResourceIDSegment.Static("staticLongTermRetentionServers", "longTermRetentionServers"),
        ResourceIDSegment.UserSpecified("longTermRetentionServerName"),
        ResourceIDSegment.Static("staticLongTermRetentionDatabases", "longTermRetentionDatabases"),
        ResourceIDSegment.UserSpecified("longTermRetentionDatabaseName"),
        ResourceIDSegment.Static("staticLongTermRetentionBackups", "longTermRetentionBackups"),
        ResourceIDSegment.UserSpecified("longTermRetentionBackupName"),
    };
}
