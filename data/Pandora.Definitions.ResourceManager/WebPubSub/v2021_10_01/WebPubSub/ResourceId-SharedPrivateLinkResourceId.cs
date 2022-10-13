using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.WebPubSub.v2021_10_01.WebPubSub;

internal class SharedPrivateLinkResourceId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.SignalRService/webPubSub/{resourceName}/sharedPrivateLinkResources/{sharedPrivateLinkResourceName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticSubscriptions", "subscriptions"),
        ResourceIDSegment.SubscriptionId("subscriptionId"),
        ResourceIDSegment.Static("staticResourceGroups", "resourceGroups"),
        ResourceIDSegment.ResourceGroup("resourceGroupName"),
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftSignalRService", "Microsoft.SignalRService"),
        ResourceIDSegment.Static("staticWebPubSub", "webPubSub"),
        ResourceIDSegment.UserSpecified("resourceName"),
        ResourceIDSegment.Static("staticSharedPrivateLinkResources", "sharedPrivateLinkResources"),
        ResourceIDSegment.UserSpecified("sharedPrivateLinkResourceName"),
    };
}
