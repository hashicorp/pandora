using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DevCenter.v2023_04_01.Images;

internal class ImageId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevCenter/devCenters/{devCenterName}/galleries/{galleryName}/images/{imageName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticSubscriptions", "subscriptions"),
        ResourceIDSegment.SubscriptionId("subscriptionId"),
        ResourceIDSegment.Static("staticResourceGroups", "resourceGroups"),
        ResourceIDSegment.ResourceGroup("resourceGroupName"),
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftDevCenter", "Microsoft.DevCenter"),
        ResourceIDSegment.Static("staticDevCenters", "devCenters"),
        ResourceIDSegment.UserSpecified("devCenterName"),
        ResourceIDSegment.Static("staticGalleries", "galleries"),
        ResourceIDSegment.UserSpecified("galleryName"),
        ResourceIDSegment.Static("staticImages", "images"),
        ResourceIDSegment.UserSpecified("imageName"),
    };
}
