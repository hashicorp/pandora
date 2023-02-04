using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Migrate.v2020_07_07.HyperVMachines;

internal class HyperVSiteMachineId : ResourceID
{
    public string? CommonAlias => "HyperVSiteMachine";

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OffAzure/hyperVSites/{hyperVSiteName}/machines/{machineName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("subscriptions", "subscriptions"),
        ResourceIDSegment.SubscriptionId("subscriptionId"),
        ResourceIDSegment.Static("resourceGroups", "resourceGroups"),
        ResourceIDSegment.ResourceGroup("resourceGroupName"),
        ResourceIDSegment.Static("providers", "providers"),
        ResourceIDSegment.ResourceProvider("resourceProvider", "Microsoft.OffAzure"),
        ResourceIDSegment.Static("hyperVSites", "hyperVSites"),
        ResourceIDSegment.UserSpecified("hyperVSiteName"),
        ResourceIDSegment.Static("machines", "machines"),
        ResourceIDSegment.UserSpecified("machineName"),
    };
}
