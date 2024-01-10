// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserAppRoleAssignedResource;

internal class UserIdAppRoleAssignedResourceId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/users/{userId}/appRoleAssignedResources/{servicePrincipalId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticUsers", "users"),
        ResourceIDSegment.UserSpecified("userId"),
        ResourceIDSegment.Static("staticAppRoleAssignedResources", "appRoleAssignedResources"),
        ResourceIDSegment.UserSpecified("servicePrincipalId")
    };
}
