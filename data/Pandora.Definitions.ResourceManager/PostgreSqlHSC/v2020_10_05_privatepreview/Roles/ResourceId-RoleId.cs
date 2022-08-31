using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PostgreSqlHSC.v2020_10_05_privatepreview.Roles;

internal class RoleId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DBforPostgreSQL/serverGroupsv2/{serverGroupName}/roles/{roleName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticSubscriptions", "subscriptions"),
        ResourceIDSegment.SubscriptionId("subscriptionId"),
        ResourceIDSegment.Static("staticResourceGroups", "resourceGroups"),
        ResourceIDSegment.ResourceGroup("resourceGroupName"),
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftDBforPostgreSQL", "Microsoft.DBforPostgreSQL"),
        ResourceIDSegment.Static("staticServerGroupsv2", "serverGroupsv2"),
        ResourceIDSegment.UserSpecified("serverGroupName"),
        ResourceIDSegment.Static("staticRoles", "roles"),
        ResourceIDSegment.UserSpecified("roleName"),
    };
}
