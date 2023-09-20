// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Groups.StableV1.GroupSiteTermStoreSetChildrenChildrenRelation;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupSiteTermStoreSetChildrenChildrenRelation";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdSiteByIdTermStoreByIdSetByIdChildrenByIdChildrenByIdRelationOperation(),
        new CreateGroupByIdSiteByIdTermStoreSetByIdChildrenByIdChildrenByIdRelationOperation(),
        new DeleteGroupByIdSiteByIdTermStoreByIdSetByIdChildrenByIdChildrenByIdRelationByIdOperation(),
        new DeleteGroupByIdSiteByIdTermStoreSetByIdChildrenByIdChildrenByIdRelationByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreByIdSetByIdChildrenByIdChildrenByIdRelationByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreByIdSetByIdChildrenByIdChildrenByIdRelationCountOperation(),
        new GetGroupByIdSiteByIdTermStoreSetByIdChildrenByIdChildrenByIdRelationByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreSetByIdChildrenByIdChildrenByIdRelationCountOperation(),
        new ListGroupByIdSiteByIdTermStoreByIdSetByIdChildrenByIdChildrenByIdRelationsOperation(),
        new ListGroupByIdSiteByIdTermStoreSetByIdChildrenByIdChildrenByIdRelationsOperation(),
        new UpdateGroupByIdSiteByIdTermStoreByIdSetByIdChildrenByIdChildrenByIdRelationByIdOperation(),
        new UpdateGroupByIdSiteByIdTermStoreSetByIdChildrenByIdChildrenByIdRelationByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
