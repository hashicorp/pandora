// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.SetGroupSiteTermStoreSetChildrenRelation;

internal class GroupIdSiteIdTermStoreSetIdChildrenIdRelationId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/groups/{groupId}/sites/{siteId}/termStore/sets/{setId}/children/{termId}/relations/{relationId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticGroups", "groups"),
        ResourceIDSegment.UserSpecified("groupId"),
        ResourceIDSegment.Static("staticSites", "sites"),
        ResourceIDSegment.UserSpecified("siteId"),
        ResourceIDSegment.Static("staticTermStore", "termStore"),
        ResourceIDSegment.Static("staticSets", "sets"),
        ResourceIDSegment.UserSpecified("setId"),
        ResourceIDSegment.Static("staticChildren", "children"),
        ResourceIDSegment.UserSpecified("termId"),
        ResourceIDSegment.Static("staticRelations", "relations"),
        ResourceIDSegment.UserSpecified("relationId")
    };
}
