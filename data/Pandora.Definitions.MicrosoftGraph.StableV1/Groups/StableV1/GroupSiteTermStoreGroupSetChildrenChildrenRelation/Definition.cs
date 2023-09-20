// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Groups.StableV1.GroupSiteTermStoreGroupSetChildrenChildrenRelation;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupSiteTermStoreGroupSetChildrenChildrenRelation";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdSiteByIdTermStoreByIdGroupByIdSetByIdChildrenByIdChildrenByIdRelationOperation(),
        new CreateGroupByIdSiteByIdTermStoreGroupByIdSetByIdChildrenByIdChildrenByIdRelationOperation(),
        new DeleteGroupByIdSiteByIdTermStoreByIdGroupByIdSetByIdChildrenByIdChildrenByIdRelationByIdOperation(),
        new DeleteGroupByIdSiteByIdTermStoreGroupByIdSetByIdChildrenByIdChildrenByIdRelationByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreByIdGroupByIdSetByIdChildrenByIdChildrenByIdRelationByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreByIdGroupByIdSetByIdChildrenByIdChildrenByIdRelationCountOperation(),
        new GetGroupByIdSiteByIdTermStoreGroupByIdSetByIdChildrenByIdChildrenByIdRelationByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreGroupByIdSetByIdChildrenByIdChildrenByIdRelationCountOperation(),
        new ListGroupByIdSiteByIdTermStoreByIdGroupByIdSetByIdChildrenByIdChildrenByIdRelationsOperation(),
        new ListGroupByIdSiteByIdTermStoreGroupByIdSetByIdChildrenByIdChildrenByIdRelationsOperation(),
        new UpdateGroupByIdSiteByIdTermStoreByIdGroupByIdSetByIdChildrenByIdChildrenByIdRelationByIdOperation(),
        new UpdateGroupByIdSiteByIdTermStoreGroupByIdSetByIdChildrenByIdChildrenByIdRelationByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
