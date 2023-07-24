using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2023_03_01.VirtualMachineImages;

internal class OfferSkuVersionId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{locationName}/edgeZones/{edgeZoneName}/publishers/{publisherName}/artifactTypes/vmImage/offers/{offerName}/skus/{skuName}/versions/{versionName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticSubscriptions", "subscriptions"),
        ResourceIDSegment.SubscriptionId("subscriptionId"),
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftCompute", "Microsoft.Compute"),
        ResourceIDSegment.Static("staticLocations", "locations"),
        ResourceIDSegment.UserSpecified("locationName"),
        ResourceIDSegment.Static("staticEdgeZones", "edgeZones"),
        ResourceIDSegment.UserSpecified("edgeZoneName"),
        ResourceIDSegment.Static("staticPublishers", "publishers"),
        ResourceIDSegment.UserSpecified("publisherName"),
        ResourceIDSegment.Static("staticArtifactTypes", "artifactTypes"),
        ResourceIDSegment.Static("staticVmImage", "vmImage"),
        ResourceIDSegment.Static("staticOffers", "offers"),
        ResourceIDSegment.UserSpecified("offerName"),
        ResourceIDSegment.Static("staticSkus", "skus"),
        ResourceIDSegment.UserSpecified("skuName"),
        ResourceIDSegment.Static("staticVersions", "versions"),
        ResourceIDSegment.UserSpecified("versionName"),
    };
}
