using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Media.v2022_08_01.LiveOutputs;

internal class LiveOutputOperationLocationId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Media/mediaServices/{accountName}/liveEvents/{liveEventName}/liveOutputs/{liveOutputName}/operationLocations/{operationId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticSubscriptions", "subscriptions"),
        ResourceIDSegment.SubscriptionId("subscriptionId"),
        ResourceIDSegment.Static("staticResourceGroups", "resourceGroups"),
        ResourceIDSegment.ResourceGroup("resourceGroupName"),
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftMedia", "Microsoft.Media"),
        ResourceIDSegment.Static("staticMediaServices", "mediaServices"),
        ResourceIDSegment.UserSpecified("accountName"),
        ResourceIDSegment.Static("staticLiveEvents", "liveEvents"),
        ResourceIDSegment.UserSpecified("liveEventName"),
        ResourceIDSegment.Static("staticLiveOutputs", "liveOutputs"),
        ResourceIDSegment.UserSpecified("liveOutputName"),
        ResourceIDSegment.Static("staticOperationLocations", "operationLocations"),
        ResourceIDSegment.UserSpecified("operationId"),
    };
}
