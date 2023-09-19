// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Groups.StableV1.GroupSiteTermStoreSetTermChildrenRelation;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupSiteTermStoreSetTermChildrenRelation";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdSiteByIdTermStoreByIdSetByIdTermByIdChildrenByIdRelationOperation(),
        new CreateGroupByIdSiteByIdTermStoreSetByIdTermByIdChildrenByIdRelationOperation(),
        new DeleteGroupByIdSiteByIdTermStoreByIdSetByIdTermByIdChildrenByIdRelationByIdOperation(),
        new DeleteGroupByIdSiteByIdTermStoreSetByIdTermByIdChildrenByIdRelationByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreByIdSetByIdTermByIdChildrenByIdRelationByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreByIdSetByIdTermByIdChildrenByIdRelationCountOperation(),
        new GetGroupByIdSiteByIdTermStoreSetByIdTermByIdChildrenByIdRelationByIdOperation(),
        new GetGroupByIdSiteByIdTermStoreSetByIdTermByIdChildrenByIdRelationCountOperation(),
        new ListGroupByIdSiteByIdTermStoreByIdSetByIdTermByIdChildrenByIdRelationsOperation(),
        new ListGroupByIdSiteByIdTermStoreSetByIdTermByIdChildrenByIdRelationsOperation(),
        new UpdateGroupByIdSiteByIdTermStoreByIdSetByIdTermByIdChildrenByIdRelationByIdOperation(),
        new UpdateGroupByIdSiteByIdTermStoreSetByIdTermByIdChildrenByIdRelationByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
