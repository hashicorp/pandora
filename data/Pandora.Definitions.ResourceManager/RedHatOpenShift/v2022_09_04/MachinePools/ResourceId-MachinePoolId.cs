using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RedHatOpenShift.v2022_09_04.MachinePools;

internal class MachinePoolId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RedHatOpenShift/openShiftClusters/{openShiftClusterName}/machinePool/{machinePoolName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticSubscriptions", "subscriptions"),
        ResourceIDSegment.SubscriptionId("subscriptionId"),
        ResourceIDSegment.Static("staticResourceGroups", "resourceGroups"),
        ResourceIDSegment.ResourceGroup("resourceGroupName"),
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftRedHatOpenShift", "Microsoft.RedHatOpenShift"),
        ResourceIDSegment.Static("staticOpenShiftClusters", "openShiftClusters"),
        ResourceIDSegment.UserSpecified("openShiftClusterName"),
        ResourceIDSegment.Static("staticMachinePool", "machinePool"),
        ResourceIDSegment.UserSpecified("machinePoolName"),
    };
}
