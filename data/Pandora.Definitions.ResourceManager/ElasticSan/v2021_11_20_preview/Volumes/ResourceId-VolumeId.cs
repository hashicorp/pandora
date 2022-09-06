using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ElasticSan.v2021_11_20_preview.Volumes;

internal class VolumeId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ElasticSan/elasticSans/{elasticSanName}/volumeGroups/{volumeGroupName}/volumes/{volumeName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticSubscriptions", "subscriptions"),
        ResourceIDSegment.SubscriptionId("subscriptionId"),
        ResourceIDSegment.Static("staticResourceGroups", "resourceGroups"),
        ResourceIDSegment.ResourceGroup("resourceGroupName"),
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftElasticSan", "Microsoft.ElasticSan"),
        ResourceIDSegment.Static("staticElasticSans", "elasticSans"),
        ResourceIDSegment.UserSpecified("elasticSanName"),
        ResourceIDSegment.Static("staticVolumeGroups", "volumeGroups"),
        ResourceIDSegment.UserSpecified("volumeGroupName"),
        ResourceIDSegment.Static("staticVolumes", "volumes"),
        ResourceIDSegment.UserSpecified("volumeName"),
    };
}
