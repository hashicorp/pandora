// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupSiteListOperation;

internal class GroupIdSiteIdListIdOperationId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/groups/{groupId}/sites/{siteId}/lists/{listId}/operations/{richLongRunningOperationId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticGroups", "groups"),
        ResourceIDSegment.UserSpecified("groupId"),
        ResourceIDSegment.Static("staticSites", "sites"),
        ResourceIDSegment.UserSpecified("siteId"),
        ResourceIDSegment.Static("staticLists", "lists"),
        ResourceIDSegment.UserSpecified("listId"),
        ResourceIDSegment.Static("staticOperations", "operations"),
        ResourceIDSegment.UserSpecified("richLongRunningOperationId")
    };
}
