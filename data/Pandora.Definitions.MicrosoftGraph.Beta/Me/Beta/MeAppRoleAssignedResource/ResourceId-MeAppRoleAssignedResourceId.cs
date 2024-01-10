// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeAppRoleAssignedResource;

internal class MeAppRoleAssignedResourceId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/appRoleAssignedResources/{servicePrincipalId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticAppRoleAssignedResources", "appRoleAssignedResources"),
        ResourceIDSegment.UserSpecified("servicePrincipalId")
    };
}
