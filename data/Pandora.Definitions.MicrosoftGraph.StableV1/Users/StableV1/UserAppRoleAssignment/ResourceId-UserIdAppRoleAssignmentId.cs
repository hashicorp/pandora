// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserAppRoleAssignment;

internal class UserIdAppRoleAssignmentId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/users/{userId}/appRoleAssignments/{appRoleAssignmentId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticUsers", "users"),
        ResourceIDSegment.UserSpecified("userId"),
        ResourceIDSegment.Static("staticAppRoleAssignments", "appRoleAssignments"),
        ResourceIDSegment.UserSpecified("appRoleAssignmentId")
    };
}
