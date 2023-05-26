using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_11_01.NetworkManagerConnections;

internal class Providers2NetworkManagerConnectionId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/providers/Microsoft.Management/managementGroups/{managementGroupId}/providers/Microsoft.Network/networkManagerConnections/{networkManagerConnectionName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftManagement", "Microsoft.Management"),
        ResourceIDSegment.Static("staticManagementGroups", "managementGroups"),
        ResourceIDSegment.UserSpecified("managementGroupId"),
        ResourceIDSegment.Static("staticProviders2", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftNetwork", "Microsoft.Network"),
        ResourceIDSegment.Static("staticNetworkManagerConnections", "networkManagerConnections"),
        ResourceIDSegment.UserSpecified("networkManagerConnectionName"),
    };
}
