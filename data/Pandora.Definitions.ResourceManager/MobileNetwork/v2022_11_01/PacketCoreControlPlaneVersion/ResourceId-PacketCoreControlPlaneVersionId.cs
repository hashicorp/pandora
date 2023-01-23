using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MobileNetwork.v2022_11_01.PacketCoreControlPlaneVersion;

internal class PacketCoreControlPlaneVersionId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/providers/Microsoft.MobileNetwork/packetCoreControlPlaneVersions/{packetCoreControlPlaneVersionName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftMobileNetwork", "Microsoft.MobileNetwork"),
        ResourceIDSegment.Static("staticPacketCoreControlPlaneVersions", "packetCoreControlPlaneVersions"),
        ResourceIDSegment.UserSpecified("packetCoreControlPlaneVersionName"),
    };
}
