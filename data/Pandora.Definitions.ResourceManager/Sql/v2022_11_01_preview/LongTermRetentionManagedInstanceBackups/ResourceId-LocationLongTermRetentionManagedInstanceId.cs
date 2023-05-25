using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2022_11_01_preview.LongTermRetentionManagedInstanceBackups;

internal class LocationLongTermRetentionManagedInstanceId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/locations/{locationName}/longTermRetentionManagedInstances/{longTermRetentionManagedInstanceName}";

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
        ResourceIDSegment.Static("staticLongTermRetentionManagedInstances", "longTermRetentionManagedInstances"),
        ResourceIDSegment.UserSpecified("longTermRetentionManagedInstanceName"),
    };
}
