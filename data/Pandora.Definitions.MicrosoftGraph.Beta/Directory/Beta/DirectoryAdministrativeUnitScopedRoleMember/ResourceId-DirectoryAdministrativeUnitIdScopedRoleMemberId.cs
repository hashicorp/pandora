// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Directory.Beta.DirectoryAdministrativeUnitScopedRoleMember;

internal class DirectoryAdministrativeUnitIdScopedRoleMemberId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/directory/administrativeUnits/{administrativeUnitId}/scopedRoleMembers/{scopedRoleMembershipId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticDirectory", "directory"),
        ResourceIDSegment.Static("staticAdministrativeUnits", "administrativeUnits"),
        ResourceIDSegment.UserSpecified("administrativeUnitId"),
        ResourceIDSegment.Static("staticScopedRoleMembers", "scopedRoleMembers"),
        ResourceIDSegment.UserSpecified("scopedRoleMembershipId")
    };
}
