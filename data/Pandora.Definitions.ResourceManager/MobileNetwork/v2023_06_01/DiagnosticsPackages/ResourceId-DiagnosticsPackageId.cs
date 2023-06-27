using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MobileNetwork.v2023_06_01.DiagnosticsPackages;

internal class DiagnosticsPackageId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MobileNetwork/packetCoreControlPlanes/{packetCoreControlPlaneName}/diagnosticsPackages/{diagnosticsPackageName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticSubscriptions", "subscriptions"),
        ResourceIDSegment.SubscriptionId("subscriptionId"),
        ResourceIDSegment.Static("staticResourceGroups", "resourceGroups"),
        ResourceIDSegment.ResourceGroup("resourceGroupName"),
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftMobileNetwork", "Microsoft.MobileNetwork"),
        ResourceIDSegment.Static("staticPacketCoreControlPlanes", "packetCoreControlPlanes"),
        ResourceIDSegment.UserSpecified("packetCoreControlPlaneName"),
        ResourceIDSegment.Static("staticDiagnosticsPackages", "diagnosticsPackages"),
        ResourceIDSegment.UserSpecified("diagnosticsPackageName"),
    };
}
