// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Groups.StableV1.GroupTransitiveMemberOf;

internal class GroupIdTransitiveMemberOfId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/groups/{groupId}/transitiveMemberOf/{directoryObjectId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticGroups", "groups"),
        ResourceIDSegment.UserSpecified("groupId"),
        ResourceIDSegment.Static("staticTransitiveMemberOf", "transitiveMemberOf"),
        ResourceIDSegment.UserSpecified("directoryObjectId")
    };
}
