// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MeAppRoleAssignment;

internal class MeAppRoleAssignmentId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/appRoleAssignments/{appRoleAssignmentId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticAppRoleAssignments", "appRoleAssignments"),
        ResourceIDSegment.UserSpecified("appRoleAssignmentId")
    };
}
