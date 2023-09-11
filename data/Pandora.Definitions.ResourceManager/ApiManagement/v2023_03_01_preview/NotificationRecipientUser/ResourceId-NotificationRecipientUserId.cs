using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2023_03_01_preview.NotificationRecipientUser;

internal class NotificationRecipientUserId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/workspaces/{workspaceId}/notifications/{notificationName}/recipientUsers/{userId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticSubscriptions", "subscriptions"),
        ResourceIDSegment.SubscriptionId("subscriptionId"),
        ResourceIDSegment.Static("staticResourceGroups", "resourceGroups"),
        ResourceIDSegment.ResourceGroup("resourceGroupName"),
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftApiManagement", "Microsoft.ApiManagement"),
        ResourceIDSegment.Static("staticService", "service"),
        ResourceIDSegment.UserSpecified("serviceName"),
        ResourceIDSegment.Static("staticWorkspaces", "workspaces"),
        ResourceIDSegment.UserSpecified("workspaceId"),
        ResourceIDSegment.Static("staticNotifications", "notifications"),
        ResourceIDSegment.Constant("notificationName", typeof(NotificationNameConstant)),
        ResourceIDSegment.Static("staticRecipientUsers", "recipientUsers"),
        ResourceIDSegment.UserSpecified("userId"),
    };
}
