// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.ServicePrincipals.Beta.ServicePrincipalRemoteDesktopSecurityConfigurationTargetDeviceGroup;

internal class ServicePrincipalIdRemoteDesktopSecurityConfigurationTargetDeviceGroupId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/servicePrincipals/{servicePrincipalId}/remoteDesktopSecurityConfiguration/targetDeviceGroups/{targetDeviceGroupId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticServicePrincipals", "servicePrincipals"),
        ResourceIDSegment.UserSpecified("servicePrincipalId"),
        ResourceIDSegment.Static("staticRemoteDesktopSecurityConfiguration", "remoteDesktopSecurityConfiguration"),
        ResourceIDSegment.Static("staticTargetDeviceGroups", "targetDeviceGroups"),
        ResourceIDSegment.UserSpecified("targetDeviceGroupId")
    };
}
