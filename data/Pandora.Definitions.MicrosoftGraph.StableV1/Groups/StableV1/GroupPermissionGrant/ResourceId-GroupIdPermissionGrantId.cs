// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Groups.StableV1.GroupPermissionGrant;

internal class GroupIdPermissionGrantId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/groups/{groupId}/permissionGrants/{resourceSpecificPermissionGrantId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticGroups", "groups"),
        ResourceIDSegment.UserSpecified("groupId"),
        ResourceIDSegment.Static("staticPermissionGrants", "permissionGrants"),
        ResourceIDSegment.UserSpecified("resourceSpecificPermissionGrantId")
    };
}
