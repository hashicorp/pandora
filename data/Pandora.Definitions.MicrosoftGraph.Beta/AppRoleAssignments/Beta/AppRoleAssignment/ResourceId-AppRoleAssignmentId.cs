// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.AppRoleAssignments.Beta.AppRoleAssignment;

internal class AppRoleAssignmentId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/appRoleAssignments/{appRoleAssignmentId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticAppRoleAssignments", "appRoleAssignments"),
        ResourceIDSegment.UserSpecified("appRoleAssignmentId")
    };
}
