using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ConnectedVmware.v2022_01_10_preview.HybridIdentityMetadata;

internal class HybridIdentityMetadataId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ConnectedVMwarevSphere/virtualMachines/{virtualMachineName}/hybridIdentityMetadata/{metadataName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticSubscriptions", "subscriptions"),
        ResourceIDSegment.SubscriptionId("subscriptionId"),
        ResourceIDSegment.Static("staticResourceGroups", "resourceGroups"),
        ResourceIDSegment.ResourceGroup("resourceGroupName"),
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftConnectedVMwarevSphere", "Microsoft.ConnectedVMwarevSphere"),
        ResourceIDSegment.Static("staticVirtualMachines", "virtualMachines"),
        ResourceIDSegment.UserSpecified("virtualMachineName"),
        ResourceIDSegment.Static("staticHybridIdentityMetadata", "hybridIdentityMetadata"),
        ResourceIDSegment.UserSpecified("metadataName"),
    };
}
