// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Groups.StableV1.GroupSiteTermStoreSetChildrenRelation;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupSiteTermStoreSetChildrenRelation";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdSiteByIdTermStoreByIdSetByIdChildrenByIdRelationOperation(),
        new CreateGroupByIdSiteByIdTermStoreSetByIdChildrenByIdRelationOperation(),
        new DeleteGroupByIdSiteByIdTermStoreByIdSetByIdChildrenByIdRelationByIdOperation(),
        new DeleteGroupByIdSiteByIdTermStoreSetByIdChildrenByIdRelationByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreByIdSetByIdChildrenByIdRelationByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreByIdSetByIdChildrenByIdRelationCountOperation(),
        new GetGroupByIdSiteByIdTermStoreSetByIdChildrenByIdRelationByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreSetByIdChildrenByIdRelationCountOperation(),
        new ListGroupByIdSiteByIdTermStoreByIdSetByIdChildrenByIdRelationsOperation(),
        new ListGroupByIdSiteByIdTermStoreSetByIdChildrenByIdRelationsOperation(),
        new UpdateGroupByIdSiteByIdTermStoreByIdSetByIdChildrenByIdRelationByIdOperation(),
        new UpdateGroupByIdSiteByIdTermStoreSetByIdChildrenByIdRelationByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
