using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.VMware.v2022_05_01.WorkloadNetworks;

internal class SegmentId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AVS/privateClouds/{privateCloudName}/workloadNetworks/default/segments/{segmentId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticSubscriptions", "subscriptions"),
        ResourceIDSegment.SubscriptionId("subscriptionId"),
        ResourceIDSegment.Static("staticResourceGroups", "resourceGroups"),
        ResourceIDSegment.ResourceGroup("resourceGroupName"),
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftAVS", "Microsoft.AVS"),
        ResourceIDSegment.Static("staticPrivateClouds", "privateClouds"),
        ResourceIDSegment.UserSpecified("privateCloudName"),
        ResourceIDSegment.Static("staticWorkloadNetworks", "workloadNetworks"),
        ResourceIDSegment.Static("staticDefault", "default"),
        ResourceIDSegment.Static("staticSegments", "segments"),
        ResourceIDSegment.UserSpecified("segmentId"),
    };
}
